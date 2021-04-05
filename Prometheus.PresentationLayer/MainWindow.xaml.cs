using Prometheus.PresentationLayer.AdminWPF;
using Prometheus.PresentationLayer.StudentWPF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prometheus.PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page newform = new User_Login_Page();
            newform.Show();

        }

        private void Window_Closed(object sender, EventArgs e)
        {

            System.Windows.Application.Current.Shutdown();
        }
    }
}
