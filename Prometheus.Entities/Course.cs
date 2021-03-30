using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Course()
        {
            CourseID = 0;
            Name = String.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
        public Course(int id, string name, DateTime startDate, DateTime endDate)
        {
            CourseID = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
