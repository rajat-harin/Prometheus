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
using Prometheus.DataAccessLayer.Repositories;

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for Add_Course_Page.xaml
    /// </summary>
    public partial class Add_Course_Page : Window
    {
        public Add_Course_Page(string UserName)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin_Main_Page form = new Admin_Main_Page(txtUserName.Text);
            form.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Course course = new Course();
                course.Name = CName.Text.ToString();
                course.StartDate = StartDate.SelectedDate.GetValueOrDefault();
                course.EndDate = EndDate.SelectedDate.GetValueOrDefault();
                CourseBL courseBL = new CourseBL();
                bool courseAdd = courseBL.AddNewCourse(course);
                if (courseAdd == true)
                {
                    MessageBox.Show("Course Added Successfully...");

                }
                else
                {
                    MessageBox.Show("Course Not Added");
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

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtUserName.Clear();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User_Login_Page user_Login_Page = new User_Login_Page();
            user_Login_Page.Show();
        }
    }
}
