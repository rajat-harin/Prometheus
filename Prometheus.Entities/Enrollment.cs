using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Enrollment()
        {
            EnrollmentID = 0;
            StudentID = 0;
            CourseID = 0;
        }
        public Enrollment(int enrollmentID, int studentID, int courseID)
        {
            EnrollmentID = enrollmentID;
            StudentID = studentID;
            CourseID = courseID;
        }
    }
}
