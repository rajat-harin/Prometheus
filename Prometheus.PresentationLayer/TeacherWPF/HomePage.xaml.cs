using Prometheus.Teacher;
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

namespace PrometheusApplication.PL
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewAllCourses form2 = new ViewAllCourses();
            form2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewMyStudents form3 = new ViewMyStudents();
            form3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HomeworkActivity form4 = new HomeworkActivity();
            form4.Show();
        }
    }
}
