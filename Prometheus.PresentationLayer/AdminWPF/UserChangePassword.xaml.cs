using Prometheus.Entities;
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
using Prometheus.BusinessLayer;

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for UserChangePassword.xaml
    /// </summary>
    public partial class UserChangePassword : Window
    {
        public UserChangePassword()
        {
            InitializeComponent();
        }
        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            User user = new User();
            teacher.UserID = txtUserName.Text.ToString();
            user.Password = txtPassword.Password.ToString();
            AdminBL adminBL = new AdminBL();
            bool result = adminBL.ChangePassword(user, user.UserID, user.Password);
            if (result == true)
            {
                MessageBox.Show("Change Successfully");
                User_Login_Page t = new User_Login_Page();
                t.Show();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
