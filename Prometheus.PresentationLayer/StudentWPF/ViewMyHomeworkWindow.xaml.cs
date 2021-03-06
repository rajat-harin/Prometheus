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
using Prometheus.BusinessLayer;
using Prometheus.Entities;

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for ViewMyHomeworkWindow.xaml
    /// </summary>
    public partial class ViewMyHomeworkWindow : Window
    {
        private StudentBL studentBL;
        private Student student;
        public ViewMyHomeworkWindow(Student student)
        {
            InitializeComponent();
            studentBL = new StudentBL();
            this.student = new Student();
            this.student = student;
            txtUserName.Text = student.UserID;
            LoadHomeworkGrid();    
        }
        public void LoadHomeworkGrid() //Creating a function to load homework grid.
        {
            try
            {
                
                ViewHomeworkDG.ItemsSource = studentBL.GetAssignedHomework(student.StudentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // back button takes back to Student Main window.
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)// pressing the close button takes us back to student main window
        {
            this.Close();
            StudentMainWindow studentMainWindowobj = new StudentMainWindow(student.UserID);
            studentMainWindowobj.Show();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
