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
    /// Interaction logic for Add_Course_Page.xaml
    /// </summary>
    public partial class Add_Course_Page : Window
    {
        public Add_Course_Page()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Course st = new Course();
            st.Name = CName.Text.ToString();
            st.StartDate = StartDate.SelectedDate.GetValueOrDefault();
            st.EndDate = EndDate.SelectedDate.GetValueOrDefault();

            CourseBL bl = new CourseBL();
            bool result = bl.AddNewCourse(st);
            if (result == true)
            {
                MessageBox.Show("Course Added");
                Admin_Main_Page f = new Admin_Main_Page();
                f.Show();
            }
            else
            {
                MessageBox.Show("Course not Added");
            }
        }
    }
}
