using Prometheus.BusinessLayer;
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

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for UserForgotPassword.xaml
    /// </summary>
    public partial class UserForgotPassword : Window
    {
        public UserForgotPassword()
        {
            InitializeComponent();
        }
        private void btnChPassword_Click(object sender, RoutedEventArgs e)
        {
            UserChangePassword frm2 = new UserChangePassword();
            frm2.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserID = txtUserName.Text.ToString();
            AdminBL adminBL = new AdminBL();

            bool result = adminBL.ForgotPassword(user);
            if (result)
            {
                MessageBox.Show("Match Found");
                UserChangePassword userChangePassword = new UserChangePassword();
                userChangePassword.Show();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
