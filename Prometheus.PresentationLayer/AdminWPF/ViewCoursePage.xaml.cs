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
    /// Interaction logic for ViewCoursePage.xaml
    /// </summary>
    public partial class ViewCoursePage : Window
    {
        public ViewCoursePage(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
        }
        private void ViewStudentPage_Load(object sender, EventArgs e)
        {

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CourseBL course = new CourseBL();
                grid.ItemsSource = course.GetCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Course course = new Course();
                course.Name = txtCName.Text.ToString();
                CourseBL courseBL = new CourseBL();
                User user = new User();
                grid.ItemsSource = courseBL.GetCourseByName(course.Name);
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
            this.Hide();
            Admin_Main_Page admin_Main_Page = new Admin_Main_Page(txtUserName.Text);
            admin_Main_Page.Show();
        }
        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            Admin_Main_Page adminMainWindowobj = new Admin_Main_Page(txtUserName.Text);
            adminMainWindowobj.Show();
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page user_Login_Page = new User_Login_Page();
            user_Login_Page.Show();
        }
    }
}
