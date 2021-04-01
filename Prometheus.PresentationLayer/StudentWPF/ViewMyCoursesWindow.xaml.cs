﻿using System;
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

namespace Prometheus.PresentationLayer.StudentWPF
{
    /// <summary>
    /// Interaction logic for ViewMyCoursesWindow.xaml
    /// </summary>
    public partial class ViewMyCoursesWindow : Window
    {
        public ViewMyCoursesWindow()
        {
            InitializeComponent();
            LoadMyCourses();

        }
        public void LoadMyCourses()//method to load my courses data grid on ViewMyCoursesWindow
        {
            try
            {
                StudentBL student = new StudentBL();
                ViewMyCoursesDG.ItemsSource = student.GetMyCourses(1).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) // implementing the back button, it takes us back to student main window.
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e) // Pressing the close button takes us back to the student main window.
        {
                this.Close();
                StudentMainWindow studentMainWindowobj = new StudentMainWindow();
                studentMainWindowobj.Show();
            }
    }
}
