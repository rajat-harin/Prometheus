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
            Teacher st = new Teacher();
            st.UserName = txtUserName.Text.ToString();
            st.Password = txtPassword.Password.ToString();
            TeacherBL bl = new TeacherBL();
            bool result = bl.LoginTeacher(st);
            if (result == true)
            {
                MessageBox.Show("Login Successful....");
                TeacherMenu menu = new TeacherMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Login Unsuccessfull....");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TeacherForgotPassword from = new TeacherForgotPassword();
            from.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
