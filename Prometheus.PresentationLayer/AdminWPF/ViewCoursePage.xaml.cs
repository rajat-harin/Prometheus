using Prometheus.BusinessLayer;
using Prometheus.Entities;
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
    /// Interaction logic for ViewCoursePage.xaml
    /// </summary>
    public partial class ViewCoursePage : Window
    {
        public ViewCoursePage()
        {
            InitializeComponent();
        }
        private void ViewStudentPage_Load(object sender, EventArgs e)
        {

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CourseBL course = new CourseBL();
            grid.ItemsSource = course.GetCourses();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Course course = new Course();
            course.Name = txtCName.Text.ToString();
            CourseBL courseBL = new CourseBL();
            User user = new User();
            grid.ItemsSource = courseBL.GetCourseByName(user.UserID);
        }
    }
}
