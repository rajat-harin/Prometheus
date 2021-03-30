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
    /// Interaction logic for ViewMyCoursesWindow.xaml
    /// </summary>
    public partial class ViewMyCoursesWindow : Window
    {
        public ViewMyCoursesWindow()
        {
            InitializeComponent();
            LoadMyCourses();

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");
        public void LoadMyCourses()//method to load my courses data grid on ViewMyCoursesWindow
        {
            SqlCommand cmd = new SqlCommand("select * from course", con);
            DataTable MyCoursesDT = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            MyCoursesDT.Load(sdr);
            con.Close();
            ViewMyCoursesDG.ItemsSource = MyCoursesDT.DefaultView;


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
