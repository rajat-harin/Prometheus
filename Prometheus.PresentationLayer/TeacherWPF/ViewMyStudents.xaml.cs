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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
using Prometheus.Exceptions;
using Prometheus.Entities;

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewMyStudents.xaml
    /// </summary>
    public partial class ViewMyStudents : Window
    {
        Student student = new Student();
        private Teacher teacher;
        StudentBL studentbl = new StudentBL();
        public ViewMyStudents(Teacher teacher)
        {
            InitializeComponent();
            GetCourses(coursecmb);
            this.teacher = new Teacher();
            this.teacher = teacher;
            txtUserName.Text = teacher.UserID;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void GetCourses(ComboBox cmbname)
        {
            try
            {
                CourseBL courseBL = new CourseBL();
                cmbname.ItemsSource = courseBL.GetCourses();
                cmbname.SelectedValuePath = "CourseID";
                cmbname.DisplayMemberPath = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int courseId;
                courseId = Convert.ToInt32(coursecmb.SelectedValue);
                studentgrid.ItemsSource = studentbl.GetStudentsByCourseId(courseId);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student();
                if(student != null)
                {
                    student = (Student)((Button)e.Source).DataContext;
                    ViewStudentCourses form1 = new ViewStudentCourses(teacher);
                    form1.idtxt.Text = Convert.ToString(student.StudentID);
                    form1.nametxt.Text = student.FName;
                    form1.Show();
                    form1.GetAllCourses(student.StudentID);
                }
                else
                {
                    MessageBox.Show("Student Other Courses Does Not Exists");
                }
                
            }
            catch (Exception ex)
            {
               
            }
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePage teacherMainWindowobj = new HomePage(teacher.UserID);
            teacherMainWindowobj.Show();
        }
        private void Window_Closed(object sender, EventArgs e) 
        {
            this.Close();
            HomePage teacherMainWindowobj = new HomePage(teacher.UserID);
            teacherMainWindowobj.Show();
        }
    }
}
