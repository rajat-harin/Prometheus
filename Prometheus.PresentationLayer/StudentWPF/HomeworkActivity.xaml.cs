﻿using Prometheus.BusinessLayer;
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
using Prometheus.BusinessLayer.Models;
using Prometheus.Exceptions;
namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for HomeworkActivity.xaml
    /// </summary>
    public partial class HomeworkActivity : Window
    {
        AssignedHomework objModelClass = new AssignedHomework();
        Homework homeworkEntity = new Homework();//Entity Initialize
        HomeworkBL homeworkBL = new HomeworkBL();//BLclass Initialize -take it into class level
        int courseID, teacherID;
        public HomeworkActivity()
        {
            InitializeComponent();
            LoadCourseComboBox();
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

        private void Add_Homework(object sender, RoutedEventArgs e)
        {
            if (coursecmbbox.SelectedValue != null)
            {
                //Adding HomeWork
                homeworkEntity.HomeworkID = Convert.ToInt32(homeworkId_txt.Text);
                homeworkEntity.Deadline = Deadline_txt.SelectedDate.Value;//DatePicker  Deadline_txt.Selecteddate.getValue.default()
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
                        MessageBox.Show("Failed to Add!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to Add!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Select Course From Courses List");
            }
        }

        private void UpdateHW_Click(object sender, RoutedEventArgs e)
        {
            homeworkEntity.HomeworkID = Convert.ToInt32(homeworkId_txt.Text);
            homeworkEntity.Description = HomeworkTitle_txt.Text;
            homeworkEntity.Deadline = Deadline_txt.SelectedDate.Value;
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

        private void SearchHW_Click(object sender, RoutedEventArgs e)
        {
            int HomeworkID = int.Parse(searchtxt.Text);
            object selectedValue = coursecmbbox.SelectedValue;
            int courseID = (int)selectedValue;//if course ID not selected then it throws exception here only - 'Object reference not set to an instance of an object.'
            if (HomeworkID != 0 && courseID != 0)
            {
                homeworkGrid.ItemsSource = homeworkBL.SearchHomeworkByID(HomeworkID, courseID);
            }
        }

        private void ViewHW_Click(object sender, RoutedEventArgs e)
        {
            homeworkGrid.ItemsSource = homeworkBL.GetAllHomeworks();
        }

        private void homeworkGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objModelClass = homeworkGrid.SelectedItem as AssignedHomework;
            homeworkId_txt.Text = Convert.ToString(objModelClass.HomeworkID);
            Deadline_txt.Text = Convert.ToString(objModelClass.Deadline);//Date Problem
            HomeworkTitle_txt.Text = Convert.ToString(objModelClass.Description);
            HomeworkDescription_txt.Text = Convert.ToString(objModelClass.LongDescription);
            /*DataGrid datagrid = (DataGrid)sender;
            DataRowView row_selected = homeworkGrid.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                homeworkId_txt.Text = row_selected["Homework ID"].ToString();
                Deadline_txt.Text = row_selected["Deadline"].ToString();
                HomeworkTitle_txt.Text = row_selected["Description"].ToString();
                HomeworkDescription_txt.Text = row_selected["Long Description"].ToString();
            }*/
        }


        private void deletebtn_Click_1(object sender, RoutedEventArgs e)
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

        private void coursecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //New Entity Assignment is Required
            //int courseId;
            //courseId = Convert.ToInt32(coursecmb.SelectedValue);
            //homeworkGrid.ItemsSource = .DefaultView;
        }
        //Refresh the Changes in the Datagrid as per the changes in the Updations, Deletions
    }
}
