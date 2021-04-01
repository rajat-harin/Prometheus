using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.Teacher.DAL;
using System.Data;
using Prometheus.Teacher.DAL.Repositories;

namespace Prometheus.Teacher.BL
{
    public class MyStudentBL
    {
        public DataTable Getstudent(int id)
        {
            return new MyStudentDAL().GetMyStudent(id);
        }
    }
}
