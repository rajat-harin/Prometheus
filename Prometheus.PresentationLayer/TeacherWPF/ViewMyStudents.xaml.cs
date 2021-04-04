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

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewMyStudents.xaml
    /// </summary>
    public partial class ViewMyStudents : Window
    {
        DataTable dt;
        //DataRow objFind;
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
            cmbname.ItemsSource = dt.DefaultView;
            cmbname.DisplayMemberPath = dt.Columns["CourseName"].ToString();
            cmbname.SelectedValuePath = dt.Columns["CourseID"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int courseId;
            courseId = Convert.ToInt32(coursecmb.SelectedValue);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                ViewStudentCourses form1 = new ViewStudentCourses();
                int id = Convert.ToInt32(dataRowView[0].ToString());
                string name = dataRowView[1].ToString() +" " +dataRowView[2].ToString();
                form1.idtxt.Text = Convert.ToString(id);
                form1.nametxt.Text = name;
                form1.Show();
                form1.GetAllCourses(id);
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