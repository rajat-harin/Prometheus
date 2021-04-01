using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.Teacher.DAL.Repositories;
using System.Data;

namespace Prometheus.Teacher.BL
{
    public class StudentOtherCoursesBL
    {
        public DataTable Getstudent(int studentid)
        {
            return new StudentOtherCoursesDAL().GetMyStudent(studentid);
        }
    }
}
