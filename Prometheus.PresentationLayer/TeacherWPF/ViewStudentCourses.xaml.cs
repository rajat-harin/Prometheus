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
using Prometheus.Entities;
using Prometheus.Exceptions;

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewStudentCourses.xaml
    /// </summary>
    public partial class ViewStudentCourses : Window
    {
        StudentBL studentbl = new StudentBL();
        private Teacher teacher;
        //DataTable dt = studentsOtherCourses.viewOtherCourse();
        public ViewStudentCourses(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = new Teacher();
            this.teacher = teacher;
            txtUserName.Text = teacher.UserID;
            
        }
        public void GetAllCourses(int studentId)
        {
            if(studentId != 0)
            {
                coursegrid.ItemsSource = studentbl.GetCoursesByStudentID(studentId);
            }
            else
            {
                MessageBox.Show("Student Does not Exists");
            }
                    
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
