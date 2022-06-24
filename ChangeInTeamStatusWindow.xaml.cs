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
    /// Логика взаимодействия для ChangeInTeamStatusWindow.xaml
    /// </summary>
    public partial class ChangeInTeamStatusWindow : Window
    {
        private User user;
        public ChangeInTeamStatusWindow(User user)
        {
            InitializeComponent();
            this.user = Helper.setUser;
            DataContext = user;
            RoleList.ItemsSource = Helper.db.InTeamStatuses.Select(q => q.InTeamStatusName).ToList();

        }

        private void ChangeInTeamStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            var role = RoleList.SelectedIndex + 1;
            TeamMember member = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == user.UserId);
            member.InTeamStatusId = role;
            Helper.db.SaveChanges();
            MessageBox.Show("Статус игрока изменен!");
            
            new MenuWindow().Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }
    }
}
