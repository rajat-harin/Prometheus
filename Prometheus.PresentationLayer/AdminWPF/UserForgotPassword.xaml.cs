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
            this.Hide();
            UserChangePassword frm2 = new UserChangePassword();
            frm2.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                User guest = new User();
                guest.UserID = txtUserName.Text.ToString();
                guest.SecurityQuestion = comboSecurity.Text.ToString();
                guest.SecurityAnswer = txtAnswer.Text.ToString();
                AdminBL adminBL = new AdminBL();
                bool result = adminBL.ForgotPassword(guest);
                if (result == true)
                {
                    MessageBox.Show("Match Found");
                    UserChangePassword userChangePassword = new UserChangePassword();
                    userChangePassword.Show();
                }
                else
                {
                    MessageBox.Show("Failed to Change Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow form = new MainWindow();
            form.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtmbl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
