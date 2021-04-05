using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
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

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for TeacherHomeworkActivity.xaml
    /// </summary>
    public partial class TeacherHomeworkActivity : Window
    {
        List<AssignedHomework> assignedHomeworks;
        AssignedHomework objModelClass;
        private Teacher teacher;
        Homework homeworkEntity = new Homework();//Entity Initialize
        HomeworkBL homeworkBL = new HomeworkBL();//BLclass Initialize -take it into class level
        int courseID, teacherID;
        public TeacherHomeworkActivity(Teacher teacher)
        {
            InitializeComponent();
            LoadCourseComboBox();
            this.teacher = new Teacher();
            this.teacher = teacher;
            txtUserName.Text = teacher.UserID;
            objModelClass = new AssignedHomework();
        }
        private void LoadCourseComboBox()
        {
            try
            {
                CourseBL courseBL = new CourseBL();
                coursecmbbox.ItemsSource = courseBL.GetCourses();
                coursecmbbox.SelectedValuePath = "CourseID";
                coursecmbbox.DisplayMemberPath = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SearchHW_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int HomeworkID = int.Parse(searchtxt.Text);
                object selectedValue = coursecmbbox.SelectedValue;
                int courseID = (int)selectedValue;//if course ID not selected then it throws exception here only - 'Object reference not set to an instance of an object.'
                if (HomeworkID != 0 && courseID != 0)
                {
                    homeworkGrid.ItemsSource = homeworkBL.SearchHomeworkByID(HomeworkID, courseID);
                }
                else
                {
                    MessageBox.Show("No Homework Found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Add_Homework(object sender, RoutedEventArgs e)
        {
            try
            {
                if (coursecmbbox.SelectedValue != null)
                {
                    //Adding HomeWork
                    homeworkEntity.HomeworkID = Convert.ToInt32(homeworkId_txt.Text);
                    homeworkEntity.Deadline = Deadline_txt.SelectedDate.Value;
                    homeworkEntity.ReqTime = Reqtime.SelectedDate.Value;//DatePicker  Deadline_txt.Selecteddate.getValue.default()
                    homeworkEntity.Description = HomeworkTitle_txt.Text;
                    homeworkEntity.LongDescription = HomeworkDescription_txt.Text; ;

                    bool ishomeworkAdded = homeworkBL.AddHomeworkBL(homeworkEntity);
                    if (ishomeworkAdded)
                    {
                        MessageBox.Show("Homework Added Successfully");
                        //Assign Assignment
                        objModelClass.HomeworkID = homeworkEntity.HomeworkID;
                        objModelClass.LongDescription = homeworkEntity.LongDescription;
                        objModelClass.Description = homeworkEntity.Description;
                        objModelClass.Deadline = homeworkEntity.Deadline;
                        objModelClass.ReqTime = homeworkEntity.ReqTime;
                        objModelClass.TeacherID = 1;//will be set as per the login id of teacher 
                        objModelClass.CourseID = (int)coursecmbbox.SelectedValue;
                        courseID = objModelClass.CourseID;
                        teacherID = objModelClass.TeacherID;
                        bool ishomeworkAssigned = homeworkBL.AssignedHomework(objModelClass);
                        if (ishomeworkAssigned)
                        {
                            MessageBox.Show("Homework Assigned Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to Assign Homework!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add Homework!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Select Course From Courses List");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void UpdateHW_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                homeworkEntity.HomeworkID = Convert.ToInt32(homeworkId_txt.Text);
                homeworkEntity.Description = HomeworkTitle_txt.Text;
                homeworkEntity.Deadline = Deadline_txt.SelectedDate.GetValueOrDefault();
                homeworkEntity.LongDescription = HomeworkDescription_txt.Text;
                bool HwUpdated = homeworkBL.updateHomework(homeworkEntity);
                if (HwUpdated)
                {
                    MessageBox.Show("Homework Updated Successfully!");
                }
                else
                {
                    MessageBox.Show("Homework not Updated!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void deletebtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int homeworkID = Convert.ToInt32(homeworkId_txt.Text);
                int AssignmentID = objModelClass.AssignmentID;
                bool HwUpdated = homeworkBL.deleteHomework_Assignment(homeworkID, AssignmentID);
                if (HwUpdated)
                {
                    MessageBox.Show("Homework Deleted Successfully!");
                }
                else
                {
                    MessageBox.Show("Homework not Deleted!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }

        private void searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void homeworkGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                objModelClass = new AssignedHomework();
                objModelClass = homeworkGrid.SelectedItem as AssignedHomework;
                if (objModelClass != null)
                {
                    homeworkId_txt.Text = Convert.ToString(objModelClass.HomeworkID);
                    Deadline_txt.Text = (objModelClass.Deadline.Date.ToString());//Date Problem
                    Reqtime.Text = (objModelClass.ReqTime.Date.ToString());//Date Problem
                    HomeworkTitle_txt.Text = Convert.ToString(objModelClass.Description);
                    HomeworkDescription_txt.Text = Convert.ToString(objModelClass.LongDescription);
                }
                else
                {
                    MessageBox.Show("No row Selected");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void homeworkId_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HomeworkDescription_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HomeworkTitle_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ViewHW_Click(object sender, RoutedEventArgs e)
        {
            //homeworkGrid.ItemsSource = homeworkBL.GetAllHomeworks();
            try
            {
                assignedHomeworks = new List<AssignedHomework>();
                assignedHomeworks = homeworkBL.GetAllHomeworks();
                homeworkGrid.ItemsSource = assignedHomeworks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
    }
}
