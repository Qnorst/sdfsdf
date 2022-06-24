using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskSearchWPF.Models;

namespace TaskSearchWPF
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        User userCap;
        bool userInTeamFlag = false;
        public MenuWindow()
        {
            InitializeComponent();
            LoadData();
            User currentUser;
            currentUser = Helper.userSession;
            DataContext = currentUser;
        }

        private void LoadData()
        {
            UserFormsDGrid.ItemsSource = Helper.db.UserForms.Where(x => x.UserId == Helper.userSession.UserId).ToList();

            TeamMember teamo = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);
            if (teamo != null)
            {
                userInTeamFlag = true;
                TeamMember teamo1 = Helper.db.TeamMembers.FirstOrDefault(q => q.InTeamStatusId == 1);
                Team teaam = Helper.db.Teams.FirstOrDefault(q => q.TeamId == teamo.TeamId);
                userCap = Helper.db.Users.FirstOrDefault(q => q.UserId == teamo1.UserId);
                TeamName.Text = teaam.TeamName.ToString();
                CaptainName.Text = userCap.UserNick.ToString();
                TeamMemsDGrid.ItemsSource = Helper.db.TeamMembers.Include(q => q.User).Include(w => w.InTeamStatus).Include(e => e.Team).Where(r => r.TeamId == teaam.TeamId).ToList();
            }
        }

        private void CreateFormBtn_Click(object sender, RoutedEventArgs e)
        {
            new FormCreateWindow().Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void CreateTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userInTeamFlag == true)
            {
                MessageBox.Show("Вы уже в команде." +
                    " Сначала выйдите из этой");
            }
            else
            {
                new TeamCreationWindow().Show();
                this.Close();
                SaveFileDialog saveFile = new SaveFileDialog();
            }
        }
        private void LeaveTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userInTeamFlag == false)
            {
                MessageBox.Show("Вы не в команде!");
            }
            else
            {
                if (Helper.userSession.UserId == userCap.UserId)
                {
                    //Диалоговое окно
                    var result = MessageBox.Show("Вы уверенны, что хотите покинуть команду? (Ваша команда распадётся)", "Выход из команды", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        //this.Close();
                    }
                    else
                    {
                        TeamMember teamMember = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);

                        Team teamToDelete = Helper.db.Teams.FirstOrDefault(t => t.TeamId == teamMember.TeamId);
                        foreach (TeamMember member in Helper.db.TeamMembers)
                        {
                            if (member.TeamId == teamToDelete.TeamId)
                            {
                                Helper.db.TeamMembers.Remove(member);
                            }
                        }
                        Helper.db.Remove(teamToDelete);
                        Helper.db.Remove(teamMember);
                        Helper.db.SaveChanges();
                        LoadData();
                    }
                }
                else
                {
                    var result = MessageBox.Show("Вы уверенны, что хотите покинуть команду?", "Выход из команды", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        //this.Close();
                    }
                    else
                    {
                        TeamMember teamMember = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);
                        Helper.db.Remove(teamMember);
                        Helper.db.SaveChanges();
                        LoadData();
                    }               
                }
            }            
        }

        private void ManageTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.userSession.UserId == userCap.UserId)
            {
                new ManageTeamWindow().Show();
                this.Close();
                SaveFileDialog saveFile = new SaveFileDialog();
            }
            else
            {
                MessageBox.Show("Вы не капитан!");
            }
        }

        private void TeamMemsDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TeamMember selectedUser = TeamMemsDGrid.SelectedItem as TeamMember;
            Helper.teamMember = selectedUser;
            if (selectedUser != null)
            {
                new TeamMemberInfoWindow(selectedUser).Show();
                this.Close();
            }
            /*            if (Helper.userSession.UserId == userCap.UserId)
                        {
                            User selectedUser = TeamMemsDGrid.SelectedItem as User;
                            Helper.setUser = selectedUser;
                            if (selectedUser != null)
                            {
                                new TeamMemberInfoWindow(selectedUser).Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы не капитан!");
                        }*/
        }

        private void UserFormsDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserForm selectedForm = UserFormsDGrid.SelectedItem as UserForm;

            Helper.userForm = selectedForm;

            if (selectedForm != null)
            {
                new EditFormWindow(selectedForm).Show();
                this.Close();
            }
        }

        private void TournamentInfoBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
