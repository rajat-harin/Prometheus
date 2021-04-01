using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prometheus.Teacher.DAL.Repositories;

namespace Prometheus.Teacher.BL
{
    public class CoursesBL
    {
        public DataTable viewCourse()
        {
            return new CourseDAL().GetCourses();
        }
    }
}




