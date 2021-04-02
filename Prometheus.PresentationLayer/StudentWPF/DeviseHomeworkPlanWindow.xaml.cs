using Prometheus.BusinessLayer;
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
    /// Interaction logic for DeviseHomeworkPlanWindow.xaml
    /// </summary>
    public partial class DeviseHomeworkPlanWindow : Window
    {
        StudentBL studentBL;
        public DeviseHomeworkPlanWindow()
        {
            InitializeComponent();
            studentBL = new StudentBL();
            DeviseHomeworkPlan();
            LoadHomeworkGrid();
        }
        //The coding here depends upon the Teacher Module Completion.
        private void BackButton_Click(object sender, RoutedEventArgs e)// pressing back button get us back to student main window.
        {
            this.Close();
        }
        private void DeviseHomeworkPlan() //Creating a function to load homework grid.
        {
            try
            {

                studentBL.DeviseHomeworkPlanByDeadline(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void LoadHomeworkGrid() //Creating a function to load homework grid.
        {
            try
            {

                DeviseHomeworkPlanDG.ItemsSource = studentBL.GetExtendedHomeworkPlan(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            StudentMainWindow studentMainWindowobj = new StudentMainWindow();
            studentMainWindowobj.Show();
        }

        private void DeviseHomeworkPlanDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }  
}
