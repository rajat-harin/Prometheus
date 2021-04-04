using Prometheus.BusinessLayer;
using Prometheus.Entities;
using Prometheus.Exceptions;
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
        public TeacherRegistration(string UserName)
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_Main_Page frm2 = new Admin_Main_Page(txtUserName.Text);
            frm2.Show();
        }

        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                User user = new User();
                teacher.FName = FName.Text.ToString();
                teacher.LName = LName.Text.ToString();
                teacher.UserID = UserName.Text.ToString();
                teacher.Address = Address.Text.ToString();
                teacher.DOB = DatePicker.SelectedDate.GetValueOrDefault();
                teacher.City = City.Text.ToString();
                string Password = txtPassword.Password.ToString();
                teacher.MobileNo = MobileNo.Text.ToString();
                teacher.IsAdmin = (bool)checkBoxIsAdmin.IsChecked;
                string SecurityQuestion = comboSecurity.Text.ToString();
                string SecurityAnswer = txtAnswer.Text.ToString();

                AdminBL bl = new AdminBL();
                bool result = bl.RegisterTeacher(teacher, Password, SecurityQuestion, SecurityAnswer);
                if (result == true)
                {
                    MessageBox.Show("Teacher Added");
                    Admin_Main_Page p = new Admin_Main_Page(txtUserName.Text);
                    p.Show();
                }
                else
                {
                    MessageBox.Show("Teacher not Added");
                }
            }
            catch (NullReferenceException nullReferenceException)
            {
                MessageBox.Show("Do not leave course name empty");
                throw nullReferenceException;
            }
            catch (Exception exception)
            {

                MessageBox.Show("Please select date as well for start and end course");
                throw exception;

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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

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
