using Prometheus.BusinessLayer;
using Prometheus.Entities;
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

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for ViewStudentPage.xaml
    /// </summary>
    public partial class ViewStudentPage : Window
    {
        public ViewStudentPage()
        {
            InitializeComponent();
        }
        private void ViewStudentPage_Load(object sender, EventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminBL adminBL = new AdminBL();
            grid.ItemsSource = adminBL.GetStudents();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.UserID = txtUserName.Text.ToString();
            AdminBL adminBL = new AdminBL();
            User user = new User();
            grid.ItemsSource = adminBL.GetStudentByUserID(student.UserID);
        }
    }
}
