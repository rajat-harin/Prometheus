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

namespace Prometheus.PresentationLayer.TeacherWPF
{
    /// <summary>
    /// Interaction logic for ViewAllCourses.xaml
    /// </summary>
    public partial class ViewAllCourses : Window
    {
        public ViewAllCourses()
        {
            InitializeComponent();
        }
        private void ShowCourses_Click(object sender, RoutedEventArgs e)
        {
            //grid.ItemsSource = new CoursesBL().viewCourse().DefaultView;
        }
    }
}
 