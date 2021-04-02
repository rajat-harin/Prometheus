using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int HomeWorkID { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
    }
}
