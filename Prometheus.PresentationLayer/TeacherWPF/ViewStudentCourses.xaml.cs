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

namespace Prometheus.Teacher
{
    /// <summary>
    /// Interaction logic for ViewStudentCourses.xaml
    /// </summary>
    public partial class ViewStudentCourses : Window
    {
        //DataTable dt = studentsOtherCourses.viewOtherCourse();
        public ViewStudentCourses()
        {
            InitializeComponent();
            
        }
        public void GetAllCourses(int studentId)
        {
            //coursegrid.ItemsSource = new StudentOtherCoursesBL().Getstudent(studentId).DefaultView;        
        }
    }
}
