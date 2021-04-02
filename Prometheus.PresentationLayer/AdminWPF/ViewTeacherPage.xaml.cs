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

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for ViewTeacherPage.xaml
    /// </summary>
    public partial class ViewTeacherPage : Window
    {
        public ViewTeacherPage()
        {
            InitializeComponent();
        }
        private void ViewTeacherPage_Load(object sender, EventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminBL adminBL = new AdminBL();
            grid.ItemsSource = adminBL.GetTeachers();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.UserID = txtUserName.Text.ToString();
            AdminBL adminBL = new AdminBL();
            User user = new User();
            grid.ItemsSource = adminBL.GetTeachersByUserID(user.UserID);
        }
    }
}
