using Prometheus.BusinessLayer;
using Prometheus.Entities;
using Prometheus.PresentationLayer.AdminWPF;
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
    /// Interaction logic for UpdateStudentProfile.xaml
    /// </summary>
    public partial class UpdateStudentProfile : Window
    {
        private Student student;
        private StudentBL studentBL;
        public UpdateStudentProfile(Student student)
        {
            InitializeComponent();
            studentBL = new StudentBL();
            this.student = new Student();
            this.student = student;
            txtUserName.Text = student.UserID;
            LoadData();
        }
        private void LoadData()
        {
            FName.Text = student.FName;
            LName.Text = student.LName;
            DOB.Text = student.DOB.Date.ToString();
            Address.Text = student.Address;
            City.Text = student.City;
        }
        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                student.Address = Address.Text.ToString();
                student.City = City.Text.ToString();

                bool result = studentBL.UpdateStudent(student);
                if (result == true)
                {
                    MessageBox.Show("Profile Updated");


                }
                else
                {
                    MessageBox.Show("Profile not Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {

        }

        private void MobileNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            StudentMainWindow studentMainWindowobj = new StudentMainWindow(student.UserID);
            studentMainWindowobj.Show();
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            User_Login_Page newform = new User_Login_Page();
            newform.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            
        }
        private void Window_Closed(object sender, EventArgs e)//to implement: close buttons opens student main window.
        {
            this.Close();
            StudentMainWindow studentMainWindowobj = new StudentMainWindow(student.UserID);
            studentMainWindowobj.Show();
        }
        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
