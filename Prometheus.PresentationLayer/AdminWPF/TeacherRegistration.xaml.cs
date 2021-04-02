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
    /// Interaction logic for TeacherRegistration.xaml
    /// </summary>
    public partial class TeacherRegistration : Window
    {
        public TeacherRegistration()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm2 = new MainWindow();
            frm2.Show();
        }

        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            User user = new User();
            teacher.FName = FName.Text.ToString();
            teacher.LName = LName.Text.ToString();
            user.UserID = UserName.Text.ToString();
            teacher.Address = Address.Text.ToString();
            teacher.DOB = DatePicker.SelectedDate.GetValueOrDefault();
            teacher.City = City.Text.ToString();
            user.Password = txtPassword.Password.ToString();
            teacher.MobileNo = MobileNo.Text.ToString();
            teacher.IsAdmin = Rolebtn.SelectedItem.ToString();

            AdminBL bl = new AdminBL();
            bool result = bl.RegisterTeacher(teacher, user.Password);
            if (result == true)
            {
                MessageBox.Show("Teacher Added");
                Admin_Main_Page p = new Admin_Main_Page();
                p.Show();
            }
            else
            {
                MessageBox.Show("Teacher not Added");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
