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
        public ViewAllCourses(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
        }
        private void ShowCourses_Click(object sender, RoutedEventArgs e)
        {
            if (courseblObj != null)
            {
                courseGrid.ItemsSource = courseblObj.GetCourses();
            }
            else
            {
                MessageBox.Show("No Courses Found!");
            }
        }

        private void courseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
 