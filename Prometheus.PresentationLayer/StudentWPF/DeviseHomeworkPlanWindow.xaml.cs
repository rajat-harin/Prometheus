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
        public DeviseHomeworkPlanWindow()
        {
            InitializeComponent();
        }
        //The coding here depends upon the Teacher Module Completion.
        private void BackButton_Click(object sender, RoutedEventArgs e)// pressing back button get us back to student main window.
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            StudentMainWindow studentMainWindowobj = new StudentMainWindow();
            studentMainWindowobj.Show();
        }

        private void DeviseHomeworkPlanDG_SelectionChanged()
        {

        }
    }  
}
