using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ManageTeamWindow.xaml
    /// </summary>
    public partial class ManageTeamWindow : Window
    {
        public ManageTeamWindow()
        {
            InitializeComponent();
            UserSearchDGrid.ItemsSource = Helper.db.UserForms.Include(q => q.User).ToList();
            TournamentsDGrid.ItemsSource = Helper.db.Tounaments.Include(q => q.TournamentStatus).Where(q => q.TournamentStatusId == 1).ToList();
        }
        private void UserSearchDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserForm selectedForm = UserSearchDGrid.SelectedItem as UserForm;
            Helper.userForma = selectedForm;
            if (selectedForm != null)
            {
                new UserInfoWindow(selectedForm).Show();
                /*this.Close();*/
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

        private void TournamentsDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Tounament selTournament = TournamentsDGrid.SelectedItem as Tounament;
            Helper.tounament = selTournament;
            if (selTournament != null)
            {
                new TakeTournamentInfo(Helper.tounament).Show();
            }
        }
    }
}
