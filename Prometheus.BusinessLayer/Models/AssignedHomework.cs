using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.BusinessLayer.Models
{
    public class AssignedHomework
    {
        public int AssignmentID { get; set; }
        public int HomeworkID { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReqTime { get; set; }
        public string LongDescription { get; set; }
        public string CourseName { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
    }
}
