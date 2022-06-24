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
    /// Логика взаимодействия для TeamCreationWindow.xaml
    /// </summary>
    public partial class TeamCreationWindow : Window
    {
        public TeamCreationWindow()
        {
            InitializeComponent();
            LoadData();



                
            User currentUser;
            currentUser = Helper.userSession;
            DataContext = currentUser;
        }
        private void LoadData()
        {
            GameChooseDGrid.ItemsSource = Helper.db.Games.ToList();
        }
        private void TeamCreateBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
