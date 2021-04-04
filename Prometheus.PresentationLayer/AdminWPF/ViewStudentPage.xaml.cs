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
    /// Interaction logic for ViewStudentPage.xaml
    /// </summary>
    public partial class ViewStudentPage : Window
    {
        public ViewStudentPage(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
        }
        private void ViewStudentPage_Load(object sender, EventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminBL adminBL = new AdminBL();
                grid.ItemsSource = adminBL.GetStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student();
                student.UserID = UserName.Text.ToString();
                AdminBL adminBL = new AdminBL();
                User user = new User();
                grid.ItemsSource = adminBL.GetStudentByUserID(student.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
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
