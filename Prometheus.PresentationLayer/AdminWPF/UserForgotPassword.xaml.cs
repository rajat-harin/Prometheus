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
            TeacherChangePassword frm2 = new TeacherChangePassword();
            frm2.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Teacher st = new Teacher();
            st.UserName = txtUserName.Text.ToString();
            TeacherBL bl = new TeacherBL();
            bool result = bl.LoginTeacherForgot(st);
            if (result == true)
            {
                MessageBox.Show("Match Found");
                TeacherChangePassword c = new TeacherChangePassword();
                c.Show();
                TeacherForgotPassword n = new TeacherForgotPassword();
                n.Hide();
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
