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

namespace Prometheus.PresentationLayer.AdminWPF
{
    /// <summary>
    /// Interaction logic for TeacherRegistration.xaml
    /// </summary>
    public partial class TeacherRegistration : Window
    {
        public TeacherRegistration()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_7(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm2 = new MainWindow();
            frm2.Show();
        }

        private void btnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher st = new Teacher();
            st.FName = FName.Text.ToString();
            st.LName = LName.Text.ToString();
            st.UserName = UserName.Text.ToString();
            st.Address = Address.Text.ToString();
            st.DOB = DatePicker.SelectedDate.GetValueOrDefault();
            st.City = City.Text.ToString();
            st.Password = txtPassword.Password.ToString();
            st.MobileNo = MobileNo.Text.ToString();
            st.IsAdmin = Rolebtn.Text.ToString();


            TeacherBL bl = new TeacherBL();
            bool result = bl.AddTeacherRegistration(st);
            if (result == true)
            {
                MessageBox.Show("Teacher Added");
            }
            else
            {
                MessageBox.Show("Teacher not Added");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}