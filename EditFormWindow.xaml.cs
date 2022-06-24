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
    /// Логика взаимодействия для EditFormWindow.xaml
    /// </summary>
    public partial class EditFormWindow : Window
    {
        private UserForm userForm;

        public EditFormWindow(UserForm userForm)
        {
            InitializeComponent();
            this.userForm = Helper.userForm;
            DataContext = userForm;
        }
        private void EditFormBtn_Click(object sender, RoutedEventArgs e)
        {
            UserForm userForm = Helper.userForm;

            userForm.FormText = FormTextBox.Text.Trim();
            userForm.UserId = Helper.userSession.UserId;
            Helper.db.SaveChanges();
            MessageBox.Show("Анкета успешно сохранена!");
            new MenuWindow().Show();
            this.Close();
        }
        private void DeleteFormBtn_Click(object sender, RoutedEventArgs e)
        {
            UserForm userForm = Helper.userForm;

            Helper.db.Remove(userForm);
            Helper.db.SaveChanges();
            MessageBox.Show("Анкета успешно удалена!");
            new MenuWindow().Show();
            this.Close();
        }
    }
}
