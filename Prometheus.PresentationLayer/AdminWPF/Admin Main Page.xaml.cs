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
using Prometheus.Entities;
using Prometheus.PresentationLayer.TeacherWPF;

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for Admin_Main_Page.xaml
    /// </summary>
    public partial class Admin_Main_Page : Window
    {
        private Teacher teacher;
        private TeacherBL teacherBL;
        public Admin_Main_Page(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
            this.teacher = new Teacher();
            this.teacher.UserID = UserName;
        }
        private void LoadTeacher()
        {
            teacher = teacherBL.GetTeacher(teacher.UserID);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow from = new MainWindow();
            from.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherRegistration from = new TeacherRegistration(txtUserName.Text);
            from.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StudentRegistration from = new StudentRegistration(txtUserName.Text);
            from.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Add_Course_Page form = new Add_Course_Page(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewTeacherPage form = new ViewTeacherPage(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewStudentPage form = new ViewStudentPage(txtUserName.Text);
            form.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Hide();
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

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewMyStudents form3 = new ViewMyStudents(teacher);
            form3.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherHomeworkActivity form4 = new TeacherHomeworkActivity(teacher);
            form4.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewAllCourses form2 = new ViewAllCourses(teacher);
            form2.Show();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            Prometheus.PresentationLayer.MainWindow obj = new Prometheus.PresentationLayer.MainWindow();
            obj.Show();
        }

        private void Window(object sender, EventArgs e)
        {

        }
    }
}
