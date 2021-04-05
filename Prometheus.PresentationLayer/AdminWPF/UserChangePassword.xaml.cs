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

            try
            {
                User user = new User();
                user.UserID = txtUserName.Text.ToString();
                user.Password = txtPassword.Password.ToString();
                AdminBL adminBL = new AdminBL();
                bool result = adminBL.ChangePassword(user);
                if (result == true)
                {
                    if (MessageBox.Show("Do you want Change Password?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Change Successfully");
                        this.Hide();
                        User_Login_Page t = new User_Login_Page();
                        t.Show();
                    }
                    else
                    {
                        this.Close();
                        MessageBox.Show("Failed to Login!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
            MainWindow from = new MainWindow();
            from.Show();
        }
        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            Admin_Main_Page adminMainWindowobj = new Admin_Main_Page(txtUserName.Text);
            adminMainWindowobj.Show();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
