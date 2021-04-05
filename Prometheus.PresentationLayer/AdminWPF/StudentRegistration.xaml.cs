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
        public StudentRegistration(string UserName)
        {
            InitializeComponent();
            txtUserName.Text = UserName;
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
            try
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
                string SecurityQuestion = comboSecurity.Text.ToString();
                string SecurityAnswer = txtAnswer.Text.ToString();

                AdminBL bl = new AdminBL();
                bool result = bl.RegisterStudent(student,Password,SecurityQuestion,SecurityAnswer);
                if (result == true)
                {
                    MessageBox.Show("Student Added");

                }
                else
                {
                    MessageBox.Show("Failed to register student!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]");
            return regex.IsMatch(str);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_Main_Page frm2 = new Admin_Main_Page(txtUserName.Text);
            frm2.Show();
        }
        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            Admin_Main_Page adminMainWindowobj = new Admin_Main_Page(txtUserName.Text);
            adminMainWindowobj.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FName.Clear();
            LName.Clear();
            UserName.Clear();
            Address.Clear();
            City.Clear();
            txtPassword.Clear();
            MobileNo.Clear();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page user_Login_Page = new User_Login_Page();
            user_Login_Page.Show();
        }

        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
