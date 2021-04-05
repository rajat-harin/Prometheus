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
using System.Data.SqlClient;
using System.Configuration;
using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
using Prometheus.Exceptions;
using Prometheus.Entities;

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewMyStudents.xaml
    /// </summary>
    public partial class ViewMyStudents : Window
    {
        StudentBL studentbl = new StudentBL();
        public ViewMyStudents(string UserName)
        {
            InitializeComponent();
            GetCourses(coursecmb);
            txtUserName.Text = UserName;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void GetCourses(ComboBox cmbname)
        {
            //dt = new CoursesBL().viewCourse();//Make my course function here so that there will always be one course for one teacher
            /*cmbname.ItemsSource = dt.DefaultView;
            cmbname.DisplayMemberPath = dt.Columns["CourseName"].ToString();
            cmbname.SelectedValuePath = dt.Columns["CourseID"].ToString();*/
            try
            {
                CourseBL courseBL = new CourseBL();
                cmbname.ItemsSource = courseBL.GetCourses();
                cmbname.SelectedValuePath = "CourseID";
                cmbname.DisplayMemberPath = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int courseId;
            courseId = Convert.ToInt32(coursecmb.SelectedValue);
            studentgrid.ItemsSource = studentbl.GetStudentsByCourseId(courseId);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                //usko bol maine sb comment kr diya except woh line
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                /*ViewStudentCourses form1 = new ViewStudentCourses(txtUserName.Text);
                int id = Convert.ToInt32(dataRowView[0].ToString());
                string name = dataRowView[1].ToString() +" " +dataRowView[2].ToString();
                form1.idtxt.Text = Convert.ToString(id);
                form1.nametxt.Text = name;
                form1.Show();
                form1.GetAllCourses(id);*/
                //This is the code which will show the button click row data. Thank you.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
/*string conection = ConfigurationManager.ConnectionStrings["TeacherConnection"].ConnectionString;

SqlConnection con = new SqlConnection(conection);
con.Open();
SqlCommand cmd = new SqlCommand("GetAllStudent", con);
cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.AddWithValue("@CourseID", coursecmb.SelectedValuePath);
SqlDataAdapter da = new SqlDataAdapter(cmd);
DataSet ds = new DataSet();
dt = new DataTable();
//da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
da.Fill(ds, "StudentCourse");
dt = ds.Tables["StudentCourse"];
SqlCommandBuilder SCB = new SqlCommandBuilder(da);
studentgrid.ItemsSource = dt.DefaultView;*/
/*coursecmb.SelectedValue = objFind[0].ToString();
//dt = StudentCourse.studentCourse();
SqlConnection con = new SqlConnection("TeacherConnection");
con.Open();
SqlCommand cmd = new SqlCommand("GetAllStudent", con);
cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.AddWithValue("@CourseID", coursecmb.SelectedValue);
SqlDataAdapter da = new SqlDataAdapter(cmd);
DataSet ds = new DataSet();
dt = new DataTable();
//da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
da.Fill(ds, "StudentCourse");
dt = ds.Tables["StudentCourse"];
SqlCommandBuilder SCB = new SqlCommandBuilder(da);
studentgrid.ItemsSource = dt.DefaultView;*/