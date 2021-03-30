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
using System.Data.SqlClient;
using System.Data;
using Prometheus.BusinessLayer;

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for EnrollForCourseWindow.xaml
    /// </summary>
    public partial class EnrollForCourseWindow : Window
    {

        public EnrollForCourseWindow()
        {
            InitializeComponent();
            LoadEnrollCourseComboBox();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");
        public void LoadEnrollCourseComboBox() //function to load the CourseID column values into the combobox. This function is called as soon as the EnrollForCourse Window is opened.
        {
            
            try
            {
                StudentBL studentBL = new StudentBL();
                EnrollCourseComboBox.ItemsSource = studentBL.GetCoursesAsList();
                EnrollCourseComboBox.SelectedValuePath = "CourseID";
                EnrollCourseComboBox.DisplayMemberPath = "Name";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        private void EnrollCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //The following code takes data from the combobox and TextBox and inserts it into the SQL Enrollment Table.
            try
            {
                string studentId = EnrollCourseStdID.Text;
                int courseId = (int) EnrollCourseComboBox.SelectedValue;
                StudentBL studentBL = new StudentBL();
                bool isEnrolled = studentBL.EnrollInCourse(studentId, courseId);
                if(isEnrolled)
                {
                    MessageBox.Show("Enrolled Successfully");
                }
                else
                {
                    MessageBox.Show("Failed to enroll!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
