using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Teaches
    {
        public int TeacherID { get; set; }
        public int CourseID { get; set; }

        public Teaches()
        {
            TeacherID = 0;
            CourseID = 0;
        }
        public Teaches(int teacherId, int courseId)
        {
            TeacherID = teacherId;
            CourseID = courseId;
        }
    }
}
