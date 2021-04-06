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
using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
using Prometheus.Exceptions;
using Prometheus.Entities;

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewAllCourses.xaml
    /// </summary>
    public partial class ViewAllCourses : Window
    {
        CourseBL courseblObj = new CourseBL();
        private Teacher teacher;
        private TeachesBL teachesBL;
        List<SelectedCourse> courses; 
        public ViewAllCourses(Teacher teacher)
        {
            InitializeComponent();
            courses = new List<SelectedCourse>();
            this.teacher = new Teacher();
            this.teacher = teacher;
            this.teachesBL = new TeachesBL();
            txtUserName.Text = teacher.UserID;
        }
        private void ShowCourses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (courseblObj != null)
                {
                    courses = courseblObj.GetCourses().Select(item => new SelectedCourse
                    {
                        CourseID = item.CourseID,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Name = item.Name,
                        isSelected = false
                    }).ToList();
                    courseGrid.ItemsSource = courses;
                }
                else
                {
                    MessageBox.Show("No Courses Found!");
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

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool isAdded;
            
            try
            {
                List<SelectedCourse> selectedCourses = new List<SelectedCourse>();
                foreach (SelectedCourse item in courseGrid.ItemsSource)
                {
                    if(item.isSelected)
                    {
                        selectedCourses.Add(item);    
                    }

                }
                isAdded=teachesBL.AddTeachesList(selectedCourses, teacher.TeacherID);
                if (isAdded)
                {
                    MessageBox.Show("Added");
                }
                else
                {
                    MessageBox.Show("Not Added");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewTeacherCourses viewTeacherCourses = new ViewTeacherCourses(teacher);
            viewTeacherCourses.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            HomePage teacherMainWindowobj = new HomePage(teacher.UserID);
            teacherMainWindowobj.Show();


        }
        private void Window_Closed(object sender, EventArgs e) 
        {
            this.Close();
      
        }
    }
}
 