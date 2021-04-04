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

namespace Prometheus.PresentationLayer.TeacherWPF
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

        //This was implemented using older method when I have created no repositores
        //here we need to take data from repo and to show the students who have opted the course
        //selected in the combobox and view ohter course button is implemented in the ViewStudentCourses.Xaml
        //that file is also implemented using the older method logic is applied we need to implement using 
        //repos and all
        public void GetAllCourses(int studentId)
        {
            //coursegrid.ItemsSource = new StudentOtherCoursesBL().Getstudent(studentId).DefaultView;        
        }
    }
}
