﻿using Prometheus.BusinessLayer;
using Prometheus.BusinessLayer.Models;
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

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for DeviseHomeworkPlanWindow.xaml
    /// </summary>
    public partial class DeviseHomeworkPlanWindow : Window
    {
        StudentBL studentBL;
        List<ExtendedHomeworkPlan> homeworkPlans;
        public DeviseHomeworkPlanWindow()
        {
            InitializeComponent();
            studentBL = new StudentBL();
            InitializeHomeworkList();
            LoadHomeworkGrid();
        }
        //The coding here depends upon the Teacher Module Completion.
        private void InitializeHomeworkList()
        {
            try
            {
                homeworkPlans = studentBL.GetExtendedHomeworkPlan(1);
            }
            catch(PrometheusException ex)
            {
                if(ex.Message.Equals("No Homework Plans Found!"))
                {
                    DeviseHomeworkPlan();
                }
            }
            
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)// pressing back button get us back to student main window.
        {
            this.Close();
        }
        private void DeviseHomeworkPlan() //Creating a function to load homework grid.
        {
            try
            {

                studentBL.DeviseHomeworkPlanByDeadline(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void LoadHomeworkGrid() //Creating a function to load homework grid.
        {
            try
            {

                DeviseHomeworkPlanDG.ItemsSource = homeworkPlans;
               
                //DeviseHomeworkPlanDG.Columns[0].IsReadOnly = true;
                //DeviseHomeworkPlanDG.Columns[1].IsReadOnly = true;
                //DeviseHomeworkPlanDG.Columns[2].IsReadOnly = true;
                //DeviseHomeworkPlanDG.Columns[3].IsReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Window_Closed(object sender, EventArgs e) // pressing close button takes us back to student main window.
        {
            this.Close();
            StudentMainWindow studentMainWindowobj = new StudentMainWindow();
            studentMainWindowobj.Show();
        }

        private void DeviseHomeworkPlanDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ExtendedHomeworkPlan> extendedHomeworkPlans = new List<ExtendedHomeworkPlan>();
                foreach (ExtendedHomeworkPlan item in DeviseHomeworkPlanDG.ItemsSource)
                {
                    extendedHomeworkPlans.Add(item);
                }
                if(studentBL.UpdateHomeworkPlanList(extendedHomeworkPlans, 1))
                {
                    MessageBox.Show("Homework Plan is Saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }  
}
