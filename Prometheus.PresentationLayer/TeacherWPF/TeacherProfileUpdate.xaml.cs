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
namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for TeacherProfileUpdate.xaml
    /// </summary>
    public partial class TeacherProfileUpdate : Window
    {
        public TeacherProfileUpdate()
        {
            InitializeComponent();
        }

      /*  private void MobileNumber_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
      */
        private void updateSub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                teacher.FName = FirstName_txt.Text.ToString();
                teacher.LName = LastName_txt.Text.ToString();

                teacher.Address = Address_txt.Text.ToString();
                teacher.DOB = DOB_txt.SelectedDate.GetValueOrDefault();
                teacher.City = City_txt.Text.ToString();

                teacher.MobileNo = MobileNumber_txt.Text.ToString();

                TeacherBL teacherbl = new TeacherBL();
                bool result = teacherbl.UpdateTeacher(teacher);
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
                MessageBox.Show(ex.Message);
            }

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
    }
}
