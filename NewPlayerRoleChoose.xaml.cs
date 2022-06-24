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
    /// Логика взаимодействия для NewPlayerRoleChoose.xaml
    /// </summary>
    public partial class NewPlayerRoleChoose : Window
    {
        private User user;
        public NewPlayerRoleChoose(User user)
        {
            InitializeComponent();
            this.user = Helper.setUser;
            DataContext = user;
            RoleList.ItemsSource = Helper.db.InTeamStatuses.Select(q => q.InTeamStatusName).ToList();
        }

        private void PickInTeamStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            TeamMember tempTM = Helper.db.TeamMembers.FirstOrDefault(q => q.UserId == Helper.userSession.UserId);
            UserForm formToDelete = Helper.userForma;
            var role = RoleList.SelectedIndex + 1;
            TeamMember member = new TeamMember()
            {
                TeamId = tempTM.TeamId,
                UserId = user.UserId,
                InTeamStatusId = role,

            };
            Helper.db.TeamMembers.Add(member);
            Helper.db.Remove(formToDelete);
            Helper.db.SaveChanges();
            MessageBox.Show("Игрок добавлен в команду!");

            new MenuWindow().Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }
    }
}
