using Prometheus.BusinessLayer;
using Prometheus.Entities;
using Prometheus.PresentationLayer.StudentWPF;
using Prometheus.PresentationLayer.TeacherWPF;
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
    /// Interaction logic for User_Login_Page.xaml
    /// </summary>
    public partial class User_Login_Page : Window
    {
        public User_Login_Page()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow from = new MainWindow();
            from.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User guest = new User();
            guest.UserID = txtUserName.Text.ToString();
            guest.Password = txtPassword.Password.ToString();
            AdminBL adminBL = new AdminBL();
            string role = adminBL.Login(guest);
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Login Unsuccessfull....");

            }
            else
            {
                MessageBox.Show("Login Successful....");
                if (role.Equals("admin"))
                {
                    Admin_Main_Page adminHomePage = new Admin_Main_Page();
                    adminHomePage.Show();
                }
                else if (role.Equals("teacher"))
                {
                    HomePage homePage = new HomePage();
                    homePage.Show();
                }
                else if (role.Equals("student"))
                {
                    StudentMainWindow studentMainWindow = new StudentMainWindow();
                    studentMainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Something went wrong...");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserForgotPassword UserForgotPassword = new UserForgotPassword();
            UserForgotPassword.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
