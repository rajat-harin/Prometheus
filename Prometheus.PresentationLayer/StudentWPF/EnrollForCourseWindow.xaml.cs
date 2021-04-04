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
using System.Data.SqlClient;
using System.Data;
using Prometheus.BusinessLayer;
using Prometheus.Entities;

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for EnrollForCourseWindow.xaml
    /// </summary>
    public partial class EnrollForCourseWindow : Window
    {
        private StudentBL studentBL;
        private Student student;
        public EnrollForCourseWindow(Student student)
        {
            InitializeComponent();
            studentBL = new StudentBL();
            this.student = new Student();
            this.student = student;
            txtUserName.Text = student.UserID;
            LoadEnrollCourseComboBox();
        }
        public void LoadEnrollCourseComboBox() //function to load the CourseID column values into the combobox. This function is called as soon as the EnrollForCourse Window is opened.
        {
            
            try
            {
                
                EnrollCourseComboBox.ItemsSource = studentBL.GetCoursesAsList();
                EnrollCourseComboBox.SelectedValuePath = "CourseID";
                EnrollCourseComboBox.DisplayMemberPath = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void EnrollCourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //The following code takes data from the combobox and TextBox and inserts it into the SQL Enrollment Table.
            try
            {
                int courseId;
                if (EnrollCourseComboBox.SelectedValue != null)
                {
                    courseId = (int)EnrollCourseComboBox.SelectedValue;
                    bool isEnrolled = studentBL.EnrollInCourse(student.StudentID, courseId);
                    if (isEnrolled)
                    {
                        MessageBox.Show("Enrolled Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to enroll!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select A course!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Already Enrolled!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e) //implentation of Back Button
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)//to implement: close buttons opens student main window.
        {
                this.Close();
                StudentMainWindow studentMainWindowobj = new StudentMainWindow(student.UserID);
                studentMainWindowobj.Show();
            }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

