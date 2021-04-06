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
        Homework homeworkEntity = new Homework();
        HomeworkBL homeworkBL = new HomeworkBL();
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
                if (coursecmbbox.SelectedValue != null)
                {
                    int HomeworkID;
                    object selectedValue = coursecmbbox.SelectedValue;
                    int courseID = (int)selectedValue;
                    if(searchtxt.Text == string.Empty)
                    {
                        MessageBox.Show("Search ID cannot be empty"); 
                    }
                    else if (courseID != 0)
                    {
                        HomeworkID = int.Parse(searchtxt.Text);
                        homeworkGrid.ItemsSource = homeworkBL.SearchHomeworkByID(HomeworkID, courseID);
                        if(HomeworkID == 0)
                        {
                                MessageBox.Show("No Homework Found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
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


        private void Add_Homework(object sender, RoutedEventArgs e)
        {
            try
            {
                if (coursecmbbox.SelectedValue != null)
                {
                    bool ishomeworkAdded;
                    if (homeworkId_txt.Text == string.Empty)
                    {
                        MessageBox.Show("Homework ID cannot be Empty!");
                    }
                    else if (Deadline_txt.SelectedDate == null)
                    {
                        MessageBox.Show("Deadline cannot be Empty!");
                    }
                    else
                    {
                        homeworkEntity.HomeworkID = Convert.ToInt32(homeworkId_txt.Text);
                        homeworkEntity.Deadline = Deadline_txt.SelectedDate.Value;
                        string currentdate = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
                        string deadline = Deadline_txt.SelectedDate.Value.ToString("dd/MM/yyyy");
                        if(string.Equals(deadline,currentdate))
                        {
                            MessageBox.Show("DeadLine cannot be the Created Date");
                        }
                        else if (HomeworkTitle_txt.Text == string.Empty)
                        {
                            MessageBox.Show("Title cannot be Empty!");  
                        }
                        else if (Reqtime.SelectedDate == null)
                        {
                            MessageBox.Show("Required Date cannot be Empty!");
                        }
                        else if(Reqtime.SelectedDate > Deadline_txt.SelectedDate)
                        {
                            MessageBox.Show("Required Date cannot be beyond Deadline!");
                        }
                        else if (HomeworkDescription_txt.Text == string.Empty)
                        {
                            MessageBox.Show("Long Description cannot be Empty!");
                        }
                        else
                        {
                            homeworkEntity.Description = HomeworkTitle_txt.Text;
                            homeworkEntity.ReqTime = Reqtime.SelectedDate.Value;
                            //Adding HomeWork

                            homeworkEntity.LongDescription = HomeworkDescription_txt.Text;
                            ishomeworkAdded = homeworkBL.AddHomeworkBL(homeworkEntity);
                            if (ishomeworkAdded)
                            {
                                MessageBox.Show("Homework Added Successfully");
                                //Assign Assignment
                                objModelClass.HomeworkID = homeworkEntity.HomeworkID;
                                objModelClass.LongDescription = homeworkEntity.LongDescription;
                                objModelClass.Description = homeworkEntity.Description;
                                objModelClass.Deadline = homeworkEntity.Deadline;
                                objModelClass.ReqTime = homeworkEntity.ReqTime;
                                objModelClass.TeacherID = 1;
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
                if (coursecmbbox.SelectedValue != null)
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

        private void deletebtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (coursecmbbox.SelectedValue != null)
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
                    Deadline_txt.Text = (objModelClass.Deadline.Date.ToString("dd/MM/yyyy"));
                    Reqtime.Text = (objModelClass.ReqTime.Date.ToString());
                    HomeworkTitle_txt.Text = Convert.ToString(objModelClass.Description);
                    HomeworkDescription_txt.Text = Convert.ToString(objModelClass.LongDescription);
                }
                else
                {
                    MessageBox.Show("Changes done in List");
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e) 
        {
            this.Close();
            HomePage teacherMainWindowobj = new HomePage(teacher.UserID);
            teacherMainWindowobj.Show();
        }

        private void ClearButton_txt_Click(object sender, RoutedEventArgs e)
        {
            coursecmbbox.SelectedIndex = -1;
            homeworkId_txt.Clear();
            Deadline_txt.SelectedDate = DateTime.Now;
            Reqtime.SelectedDate = DateTime.Now;
            HomeworkTitle_txt.Clear();
            HomeworkDescription_txt.Clear();
            searchtxt.Clear();
        }

        private void ViewHW_Click(object sender, RoutedEventArgs e)
        {
           
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
