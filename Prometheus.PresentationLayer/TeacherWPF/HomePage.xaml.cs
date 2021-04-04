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

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewAllCourses form2 = new ViewAllCourses();
            form2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewMyStudents form3 = new ViewMyStudents();
            form3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HomeworkActivity form4 = new HomeworkActivity();
            form4.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherProfileUpdate form5 = new TeacherProfileUpdate();
            form5.Show();
        }
    }
}
