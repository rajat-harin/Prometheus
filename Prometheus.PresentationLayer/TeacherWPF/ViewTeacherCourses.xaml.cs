using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
using Prometheus.Entities;
using Prometheus.Exceptions;
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

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewTeacherCourses.xaml
    /// </summary>
    public partial class ViewTeacherCourses : Window
    {
        private TeacherBL teacherBL;
        private Teacher teacher;
        public ViewTeacherCourses(Teacher teacher)
        {
            InitializeComponent();
            teacherBL = new TeacherBL();
            this.teacher = new Teacher();
            txtUserName.Text = teacher.UserID;
            this.teacher = teacher;
            LoadMyCourses();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void LoadMyCourses()//method to load my courses data grid on ViewMyCoursesWindow
        {
            try
            {
                List<TeacherCourses> teacherCourses = teacherBL.GetCoursesByTeacherID(teacher.TeacherID);//id set to 1 just for testing
                if (teacherCourses.Any())
                {
                    ViewMyCoursesDG.ItemsSource = teacherCourses;
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

        private void courseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
