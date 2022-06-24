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

namespace TaskSearchWPF
{
    /// <summary>
    /// Логика взаимодействия для TeamTournamentsWindow.xaml
    /// </summary>
    public partial class TeamTournamentsWindow : Window
    {
        public TeamTournamentsWindow()
        {
            InitializeComponent();
/*            TeamMember teamMember = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);
            Team newteam = Helper.db.Teams.FirstOrDefault(q => q.TeamId == teamMember.TeamId);
            CurrentTournamentsDGrid.ItemsSource = Helper.db.TounamentTeams.Include(q => q.Tournament).Include(q => q.Team).ToList();
            PastTournamentsDGrid.ItemsSource = Helper.db.TounamentTeams.Include(q => q.Tournament).Include(q => q.Team).Where(a => a.TeamId == newteam.TeamId).ToList();*/
        }

        private void LoadDatat()
        {
            
        }

        private void PastTournamentsDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void CurrentTournamentsDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
