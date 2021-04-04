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
using Prometheus.PresentationLayer.TeacherWPF;

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for Admin_Main_Page.xaml
    /// </summary>
    public partial class Admin_Main_Page : Window
    {
        public Admin_Main_Page(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow from = new MainWindow();
            from.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            TeacherRegistration from = new TeacherRegistration(txtUserName.Text);
            from.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            StudentRegistration from = new StudentRegistration(txtUserName.Text);
            from.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            Add_Course_Page form = new Add_Course_Page(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            ViewTeacherPage form = new ViewTeacherPage(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            ViewStudentPage form = new ViewStudentPage(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            
            ViewCoursePage form = new ViewCoursePage(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page admin_Main_Page = new User_Login_Page();
            admin_Main_Page.Show();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
           // ViewMyCourses viewMyCourses = new ViewMyCourses();

        }
    }
}
