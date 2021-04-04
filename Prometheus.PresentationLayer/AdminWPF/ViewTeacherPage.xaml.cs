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
    /// Interaction logic for ViewTeacherPage.xaml
    /// </summary>
    public partial class ViewTeacherPage : Window
    {
        public ViewTeacherPage(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
        }
        private void ViewTeacherPage_Load(object sender, EventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                AdminBL adminBL = new AdminBL();
                grid.ItemsSource = adminBL.GetTeachers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                teacher.UserID = UserName.Text.ToString();
                AdminBL adminBL = new AdminBL();
                grid.ItemsSource = adminBL.GetTeachersByUserID(teacher.UserID);
                teacher.IsAdmin.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtUserName1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Admin_Main_Page admin_Main_Page = new Admin_Main_Page(txtUserName.Text);
            admin_Main_Page.Show();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page user_Login_Page = new User_Login_Page();
            user_Login_Page.Show();
        }
    }
}
