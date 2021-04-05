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
using Prometheus.BusinessLayer;
using Prometheus.DataAccessLayer;
using Prometheus.Entities;
using Prometheus.Exceptions;
using System.Text.RegularExpressions;
using Prometheus.PresentationLayer.AdminWPF;

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for TeacherProfileUpdate.xaml
    /// </summary>
    public partial class TeacherProfileUpdate : Window
    {
        private Teacher teacher;
        private TeacherBL teacherBL;
        public TeacherProfileUpdate(Teacher teacher)
        {
            InitializeComponent();
            teacherBL = new TeacherBL();
            this.teacher = new Teacher();
            this.teacher = teacher;
            txtUserName.Text = teacher.UserID;
            LoadData();
        }
        private void LoadData()
        {
            FName.Text = teacher.FName;
            LName.Text = teacher.LName;
            DOB.Text = teacher.DOB.Date.ToString();
            Address.Text = teacher.Address;
            City.Text = teacher.City;
        }

        /*  private void MobileNumber_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
          {
              Regex regex = new Regex("[^0-9]+");
              e.Handled = regex.IsMatch(e.Text);
          }
        */
        private void updateSub_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TeacherID_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void textUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstName_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void City_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      

        private void Address_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MobileNumber_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            User_Login_Page login_Page = new User_Login_Page();
            login_Page.Show();
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

        private void DOB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                teacher.Address = Address.Text.ToString();
                teacher.City = City.Text.ToString();

                bool result = teacherBL.UpdateTeacher(teacher);
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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
