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
using Prometheus.Entities;
using Prometheus.BusinessLayer.Models;
using Prometheus.Exceptions;

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for ViewMyCoursesWindow.xaml
    /// </summary>
    public partial class ViewMyCoursesWindow : Window
    {
        private StudentBL objStudentBL;
        public ViewMyCoursesWindow()
        {
            InitializeComponent();
            objStudentBL = new StudentBL();
            LoadMyCourses();
        }
        public void LoadMyCourses()//method to load my courses data grid on ViewMyCoursesWindow
        {
            try
            {
                List<EnrolledCourse> enrolledCourses = objStudentBL.GetCoursesByStudentID(1);//id set to 1 just for testing
                if (enrolledCourses.Any())
                {
                    ViewMyCoursesDG.ItemsSource = enrolledCourses;
                }
                else
                {
                    throw new PrometheusException("No Courses Found!");
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // implementing the back button, it takes us back to student main window.
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e) // Pressing the close button takes us back to the student main window.
        {
                this.Close();
                StudentMainWindow studentMainWindowobj = new StudentMainWindow(txtUserName.Text);
                studentMainWindowobj.Show();
            }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
