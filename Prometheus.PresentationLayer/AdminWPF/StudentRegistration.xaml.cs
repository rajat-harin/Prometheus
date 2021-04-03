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
    /// Interaction logic for StudentRegistration.xaml
    /// </summary>
    public partial class StudentRegistration : Window
    {
        public StudentRegistration()
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

        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            User user = new User();
            student.FName = FName.Text.ToString();
            student.LName = LName.Text.ToString();
            student.UserID = UserName.Text.ToString();
            student.Address = Address.Text.ToString();
            student.DOB = DatePicker.SelectedDate.GetValueOrDefault();
            student.City = City.Text.ToString();
            string Password = txtPassword.Password.ToString();
            student.MobileNo = MobileNo.Text.ToString();
            MessageBox.Show(user.UserID);
            AdminBL bl = new AdminBL();
            bool result = bl.RegisterStudent(student, Password);
            if (result == true)
            {
                MessageBox.Show("Student Added");
                Admin_Main_Page p = new Admin_Main_Page();
                p.Show();
            }
            else
            {
                MessageBox.Show("Student not Added");
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm2 = new MainWindow();
            frm2.Show();
        }
    }
}
