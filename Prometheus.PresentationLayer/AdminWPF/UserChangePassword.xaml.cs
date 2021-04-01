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
            Teacher st = new Teacher();
            st.UserName = txtUserName.Text.ToString();
            st.Password = txtPassword.Password.ToString();
            TeacherBL bl = new TeacherBL();
            bool result = bl.LoginTeacherChangePassword(st);
            if (result == true)
            {
                MessageBox.Show("Change Successfully");
                Teacher_Login_Page t = new Teacher_Login_Page();
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
