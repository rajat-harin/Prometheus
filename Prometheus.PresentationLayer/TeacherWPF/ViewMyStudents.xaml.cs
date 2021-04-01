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

namespace Prometheus.Teacher
{
    /// <summary>
    /// Interaction logic for ViewMyStudents.xaml
    /// </summary>
    public partial class ViewMyStudents : Window
    {
        DataTable dt;
        //DataRow objFind;
        public ViewMyStudents()
        {
            InitializeComponent();
            GetCourses(coursecmb);
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
            /*int courseId;
            string conection = ConfigurationManager.ConnectionStrings["TeacherConnection"].ConnectionString;
            SqlConnection objCon = new SqlConnection(conection);
            SqlCommand objCom = new SqlCommand("GetAllStudent", objCon);
            objCom.CommandType = CommandType.StoredProcedure;
            courseId = Convert.ToInt32(coursecmb.SelectedValue);
            objCom.Parameters.AddWithValue("@CourseID", courseId);
            objCon.Open();
            SqlDataAdapter objDR =  new SqlDataAdapter(objCom);
            DataTable objDT = new DataTable();
            objDR.Fill(objDT);
            objCon.Close();
            studentgrid.ItemsSource = objDT.DefaultView;         
            //error: coursecmb.SelectedValue = objFind[0].ToString();
            //dt = StudentCourse.studentCourse();
            //when using dataset use dt.Tables[0].Columns["ZoneName"].ToString();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int courseId;
            courseId = Convert.ToInt32(coursecmb.SelectedValue);
            //studentgrid.ItemsSource = new MyStudentBL().Getstudent(courseId).DefaultView;
            /*
            string conection = ConfigurationManager.ConnectionStrings["TeacherConnection"].ConnectionString;
            SqlConnection objCon = new SqlConnection(conection);
            SqlCommand objCom = new SqlCommand("GetAllStudent", objCon);
            objCom.CommandType = CommandType.StoredProcedure; 
            int rowCount = studentgrid.Items.Count - 1;
            // Get the no. of columns in the first row.
            int colCount = studentgrid.Columns.Count;
            MessageBox.Show(Convert.ToString(rowCount + "," + colCount));
            // Create a Save button column
            DataGrid d1 = new DataGrid();
            DataGridTextColumn t1 = new DataGridTextColumn();
            t1.Header = "View Other Course Information";
            d1.Columns.Add(t1);*/
            // Set column values
            // columnSave.Name = "View Other Course Information";
            //studentgrid.Columns.Insert((colCount + 1), columnSave);
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