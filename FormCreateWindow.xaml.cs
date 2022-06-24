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
    /// Логика взаимодействия для FormCreateWindow.xaml
    /// </summary>
    public partial class FormCreateWindow : Window
    {
        public FormCreateWindow()
        {
            InitializeComponent();
            User currentUser;
            currentUser = Helper.userSession;
            DataContext = currentUser;
            RoleList.ItemsSource = Helper.db.InTeamStatuses.Select(q => q.InTeamStatusName).ToList();
            GameList.ItemsSource = Helper.db.Games.Select(q => q.GameName).ToList();
        }

        private void CreateFormBtn_Click(object sender, RoutedEventArgs e)
        {

            string FormText = FormDescriptionBox.Text.Trim();
            int UserId = Helper.userSession.UserId;
            var role = RoleList.SelectedIndex;
            var selest = GameList.SelectedIndex;

            UserForm form = new UserForm()
            {
                UserId = UserId,
                FormText = FormText,
            };
            Helper.db.UserForms.Add(form);
            Helper.db.SaveChanges();

            MessageBox.Show("Анкета создана!");

            new MenuWindow().Show();
            this.Close();
        }
    }
}
