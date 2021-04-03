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
    /// Interaction logic for Admin_Main_Page.xaml
    /// </summary>
    public partial class Admin_Main_Page : Window
    {
        public Admin_Main_Page()
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
            TeacherRegistration from = new TeacherRegistration();
            from.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StudentRegistration from = new StudentRegistration();
            from.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Add_Course_Page form = new Add_Course_Page();
            form.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewTeacherPage form = new ViewTeacherPage();
            form.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ViewStudentPage form = new ViewStudentPage();
            form.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ViewCoursePage form = new ViewCoursePage();
            form.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            User_Login_Page user_Login_Page = new User_Login_Page();
            user_Login_Page.Show();
            Admin_Main_Page admin_Main_Page = new Admin_Main_Page();
            admin_Main_Page.Hide();
        }
    }
}
