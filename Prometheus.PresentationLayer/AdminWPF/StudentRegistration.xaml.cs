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
            Student st = new Student();
            st.FName = FName.Text.ToString();
            st.LName = LName.Text.ToString();
            st.UserName = UserName.Text.ToString();
            st.Address = Address.Text.ToString();
            st.DOB = DatePicker.SelectedDate.GetValueOrDefault();
            st.City = City.Text.ToString();
            st.Password = txtPassword.Password.ToString();
            st.MobileNo = MobileNo.Text.ToString();

            StudentBL bl = new StudentBL();
            bool result = bl.AddStudentRegistration(st);
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
