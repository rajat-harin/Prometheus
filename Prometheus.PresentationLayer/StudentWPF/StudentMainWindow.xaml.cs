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

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for StudentMainWindow.xaml
    /// </summary>
    public partial class StudentMainWindow : Window
    {
        //string connectionstring = "put connection string here; Integrated Security = True;" ;
        public StudentMainWindow()
        {
            InitializeComponent();
        }

        private void ViewMyHomeworkBt_Click(object sender, RoutedEventArgs e) //opens ViewMyHomeworkWindow
        {
            this.Hide();
            ViewMyHomeworkWindow ViewMyHW = new ViewMyHomeworkWindow();
            ViewMyHW.Show();

            //using (SqlConnection sqlcon = new SqlConnection(connectionstring);
            //{
            //    sqlcon.Open();
            //    SqlDataAdapter sqlda = new SqlDataAdapter(DragEnter column name or table name using select query here, sqlcon );
            //    DataTable dtbl = new DataTable();
            //    sqlda.Fill(dtbl);
            //}



        }

        private void ViewMyCourseBt_Click(object sender, RoutedEventArgs e) //opens ViewMyCoursesWindow 
        {
            this.Hide();
            ViewMyCoursesWindow ViewMyCourse = new ViewMyCoursesWindow();
            ViewMyCourse.Show();
        }

        private void DeviseHomeworkPlanBt_Click(object sender, RoutedEventArgs e) //opens DeviseHomeworkPlanWindow
        {
            this.Hide();
            DeviseHomeworkPlanWindow DevisePlanWindow = new DeviseHomeworkPlanWindow();
            DevisePlanWindow.Show();
        }

        private void CourseEnrollBt_Click(object sender, RoutedEventArgs e) //opens EnrollForCourseWindow
        {
            this.Hide();
            EnrollForCourseWindow CourseEnrollWindow = new EnrollForCourseWindow();
            CourseEnrollWindow.Show();
        }
    }
}
