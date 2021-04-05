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
        List<SelectedCourse> courses; 
        public ViewAllCourses(string UserName)
        {
            InitializeComponent();
            courses = new List<SelectedCourse>();
            txtUserName.Text = UserName;
        }
        private void ShowCourses_Click(object sender, RoutedEventArgs e)
        {
            if (courseblObj != null)
            {
                //old line below
                //courseGrid.ItemsSource = courseblObj.GetCourses();

                //code by rajat
                courses = courseblObj.GetCourses().Select(item => new SelectedCourse
                {
                    CourseID = item.CourseID,
                    StartDate =item.StartDate,
                    EndDate = item.EndDate,
                    Name = item.Name,
                    isSelected = false
                }).ToList();
                courseGrid.ItemsSource = courses;
                //
            }
            else
            {
                MessageBox.Show("No Courses Found!");
            }
        }

        private void courseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Code commented by rajat
            /*
            try
            {
                
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                int CourseId = Convert.ToInt32(dataRowView[0].ToString());
                int TeacherID = 1;
                //Write logic here for checking if checkbox is clicked then move the data into teaches table
                //and then after clicking on mycourses retrive the data from teaches and courses join
                



        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int TeacherID  = 1;
            
            try
            {
                List<SelectedCourse> selectedCourses = new List<SelectedCourse>();
                foreach (SelectedCourse item in courseGrid.ItemsSource)
                {
                    if(item.isSelected)
                    {
                        selectedCourses.Add(item);
                        
                        
                    }
                    //courseblObj.GetCourses(item.CourseID,TeacherID);

                }
                //Now you can pass list selected courses to BL for adding in Database
                //Your Code here  --  mujhe selected courses teaches table ka jomodel hai usme bhejana hai and then mycourses me wo course id and teacher id se sare teacher courses dikhana hai
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
 