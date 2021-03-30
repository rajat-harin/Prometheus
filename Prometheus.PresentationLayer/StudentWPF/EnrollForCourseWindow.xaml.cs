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
using System.Data.SqlClient;
using System.Data;

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for EnrollForCourseWindow.xaml
    /// </summary>
    public partial class EnrollForCourseWindow : Window
    {

        public EnrollForCourseWindow()
        {
            InitializeComponent();
            LoadEnrollCourseComboBox();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");
        public void LoadEnrollCourseComboBox() //function to load the CourseID column values into the combobox. This function is called as soon as the EnrollForCourse Window is opened.
        {
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select CourseID from course", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            EnrollCourseComboBox.ItemsSource = dt.DefaultView;
            EnrollCourseComboBox.DisplayMemberPath = "CourseID";


            // SqlDataReader sdr;
            // try
            //{
            //     con.Open();
            //     sdr = cmd.ExecuteReader();
            //     while (sdr.Read())
            //     {
            //        string courseID = sdr.GetString("CourseID");
            //     }
            // }


            //SqlDataAdapter da = new SqlDataAdapter("select CourseID from course", con);
            //DataSet ds = new DataSet();
            //EnrollCourseComboBox.ItemsSource = ds.Tables[0].DefaultView;
            //EnrollCourseComboBox.DisplayMemberPath = ds.Tables[0].Columns["CourseID"].ToString();


        }
        private void EnrollCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//The following code takes data from the combobox and TextBox and inserts it into the SQL Enrollment Table.
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into Enrollment (CourseID, StudentID) values (' " + EnrollCourseComboBox.Text + "' , '" + EnrollCourseComboBox.Text + " '); ", con);
            con.Open();
            cmd.ExecuteNonQuery();



            //try
            //{
            //    //Dataset1TableAdapters.stdInfo
            //}
        }
    }
}
