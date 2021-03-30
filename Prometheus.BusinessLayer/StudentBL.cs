using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.DataAccessLayer.Repositories;

namespace Prometheus.BusinessLayer
{
    public class StudentBL
    {
        public DataTable GetMyCourses(int id)
        {
            return new StudentDAL().GetMyCourses(id).Tables[0];
        }
    }
}
