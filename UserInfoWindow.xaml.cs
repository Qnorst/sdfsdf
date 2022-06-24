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
    /// Логика взаимодействия для UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        private User userCap;
        private UserForm userForm;
        public UserInfoWindow(UserForm userForm)
        {
            InitializeComponent();
            this.userForm = userForm;
            DataContext = userForm;
            User user = Helper.db.Users.FirstOrDefault(q => q.UserId == userForm.UserId);
            Helper.setUser = user;
            UserName.Text = user.UserName;
            FormText.Text = userForm.FormText;
            UserSurname.Text = user.UserSurname;
            UserNick.Text = user.UserNick;
        }
        private void TakeToTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            new NewPlayerRoleChoose(Helper.setUser).Show();
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }
        private void CloseUserInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            /*new MenuWindow().Show();*/
            this.Close();
            SaveFileDialog saveFile = new SaveFileDialog();
        }

    }
}
