using Prometheus.BusinessLayer;
using Prometheus.Entities;
using Prometheus.PresentationLayer.AdminWPF;
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

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for StudentMainWindow.xaml
    /// </summary>
    public partial class StudentMainWindow : Window
    {
        //string connectionstring = "put connection string here; Integrated Security = True;" ;
        private Student student;
        private StudentBL studentBL;
        public StudentMainWindow(string UserName)
        {
            InitializeComponent();
            studentBL = new StudentBL();
            student = new Student();
            
            student.UserID = UserName;
            txtUserName.Text = UserName;
            LoadStudent();
        }
        private void LoadStudent()
        {
            try
            {
                student = studentBL.GetStudent(student.UserID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ViewMyHomeworkBt_Click(object sender, RoutedEventArgs e) //opens ViewMyHomeworkWindow
        {
            this.Hide();
            ViewMyHomeworkWindow ViewMyHW = new ViewMyHomeworkWindow(student);
            ViewMyHW.Show();

            //using (SqlConnection sqlcon = new SqlConnection(connectionstring);
            //{
            //    sqlcon.Open();
            //    SqlDataAdapter sqlda = new SqlDataAdapter(DragEnter column name or table name using select query here, sqlcon );
            //    DataTable dtbl = new DataTable();
            //    sqlda.Fill(dtbl);
            //}



        }

        private void ViewMyCourseBt_Click(object sender, RoutedEventArgs e) //opens ViewMyCoursesWindow 
        {
            this.Hide();
            ViewMyCoursesWindow ViewMyCourse = new ViewMyCoursesWindow(student);
            ViewMyCourse.Show();
        }

        private void DeviseHomeworkPlanBt_Click(object sender, RoutedEventArgs e) //opens DeviseHomeworkPlanWindow
        {
            this.Hide();
            DeviseHomeworkPlanWindow DevisePlanWindow = new DeviseHomeworkPlanWindow(student);
            DevisePlanWindow.Show();
        }

        private void CourseEnrollBt_Click(object sender, RoutedEventArgs e) //opens EnrollForCourseWindow
        {
            this.Hide();
            EnrollForCourseWindow CourseEnrollWindow = new EnrollForCourseWindow(student);
            CourseEnrollWindow.Show();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page newform = new User_Login_Page();
            newform.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UpdateStudentProfile newform = new UpdateStudentProfile(student);
            newform.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
            User_Login_Page objLoginPage = new User_Login_Page();
            objLoginPage.Show();
        }
    }
}
