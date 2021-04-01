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
using Prometheus.Teacher.BL;
using Entities;

namespace Prometheus.Teacher
{
    /// <summary>
    /// Interaction logic for HomeworkActivity.xaml
    /// </summary>
    public partial class HomeworkActivity : Window
    {
        public HomeworkActivity()
        {
            InitializeComponent();
        }

        private void Add_Homework(object sender, RoutedEventArgs e)
        {
            Homework newHomework = new Homework();//Entity Initialize
            HomeworkBL newBL = new HomeworkBL();//BLclass Initialize -take it into class level
            //check values for textboxes
            newHomework.Deadline = DateTime.Parse(Deadline_txt.Text);//DatePicker  Deadline_txt.Selecteddate.getValue.default()
            newHomework.Description = HomeworkTitle_txt.Text;
            newHomework.LongDescription = HomeworkDescription_txt.Text;
            bool homeworkAdded = newBL.AddHomeworkBL(newHomework);
            if (homeworkAdded)
                MessageBox.Show("HomeWork Added");
            else
                MessageBox.Show("HomeWoek not Added");
        }

        private void UpdateHW_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchHW_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
