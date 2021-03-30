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
    /// Interaction logic for ViewMyHomeworkWindow.xaml
    /// </summary>
    public partial class ViewMyHomeworkWindow : Window
    {
        public ViewMyHomeworkWindow()
        {
            InitializeComponent();
            LoadHomeworkGrid();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6FKA8SI;Initial Catalog=Prometheus;Integrated Security=True");


        public void LoadHomeworkGrid() //Creating a function to load homework grid.
        {
            SqlCommand cmd = new SqlCommand("select * from Homework ", con);
            DataTable HomeworkDT = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            HomeworkDT.Load(sdr);
            con.Close();
            ViewHomeworkDG.ItemsSource = HomeworkDT.DefaultView;


        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
