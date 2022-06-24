using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для TeamMemberInfoWindow.xaml
    /// </summary>
    public partial class TeamMemberInfoWindow : Window
    {
        private TeamMember teamMember;
        private User userCap;
        public TeamMemberInfoWindow(TeamMember teamMember)
        {
            InitializeComponent();
            this.teamMember = Helper.teamMember;
            DataContext = teamMember;
            User user = Helper.db.Users.FirstOrDefault(q => q.UserId == teamMember.UserId);
            Helper.setUser = user;
            UserName.Text = user.UserName;
            UserInTeamStatus.Text = teamMember.InTeamStatus.InTeamStatusName;
            UserSurname.Text = user.UserSurname;
            UserNick.Text = user.UserNick;
            TeamMember teamo1 = Helper.db.TeamMembers.FirstOrDefault(q => q.InTeamStatusId == 1);
            userCap = Helper.db.Users.FirstOrDefault(q => q.UserId == teamo1.UserId);
        }

        private void ChangeInTeamStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.userSession.UserId == userCap.UserId)
            {
                new ChangeInTeamStatusWindow(Helper.setUser).Show();
                this.Close();
                SaveFileDialog saveFile = new SaveFileDialog();
            }
            else
            {
                MessageBox.Show("Вы не капитан!");
            }
        }

        private void KickFromTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.userSession.UserId == userCap.UserId)
            {
                var result = MessageBox.Show("Вы уверенны, что хотите исключить игрока?", "Исключение из команды", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    //this.Close();
                }
                else
                {
                    TeamMember teamMember = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.setUser.UserId);                   
                    Helper.db.Remove(teamMember);
                    Helper.db.SaveChanges();
                    MessageBox.Show("Игрок исключен!");
                    new MenuWindow().Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не капитан!");
            }
        }

        private void CloseMemberInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow().Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }
    }
}
