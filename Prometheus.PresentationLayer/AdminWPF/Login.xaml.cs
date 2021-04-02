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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Admin_Main_Page frm2 = new Admin_Main_Page();
            frm2.Show();
        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
