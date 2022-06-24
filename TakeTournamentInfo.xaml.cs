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
    /// Логика взаимодействия для TakeTournamentInfo.xaml
    /// </summary>
    public partial class TakeTournamentInfo : Window
    {
        Tounament tounament;
        public TakeTournamentInfo(Tounament tounament)
        {
            InitializeComponent();
            this.tounament = tounament;
            DataContext = tounament;
        }

        private void TakePartInTournamentBtn_Click(object sender, RoutedEventArgs e)
        {
            TeamMember tempTM = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);
            Team team = Helper.db.Teams.FirstOrDefault(q => q.TeamId == tempTM.TeamId);
            TounamentTeam tounamentTeam = new TounamentTeam()
            {
                TeamId = team.TeamId,
                TournamentId = tounament.TounamentId
            };
            Helper.db.TounamentTeams.Add(tounamentTeam);
            Helper.db.SaveChanges();
            MessageBox.Show("Запись успешна!");

            new MenuWindow().Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }

        private void CloseTournamentInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
