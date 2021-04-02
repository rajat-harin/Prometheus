using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.BusinessLayer
{
    public class TeacherBL
    {
        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    TeacherRepo teacherRepo = new TeacherRepo();
                    if (teacherRepo.UpdateTeacher(teacher))
                    {
                        return true;
                    }
                    else
                    {
                        throw new PrometheusException("Teacher Updated");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }

        public bool DeleteTeacher(Teacher teacher)
        {
            try
            {
                if (teacher != null)
                {
                    TeacherRepo teacherRepo = new TeacherRepo();
                    if (teacherRepo.DeleteTeacher(teacher))
                    {
                        return true;
                    }
                    else
                    {
                        throw new PrometheusException("Teacher Deleted");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }
    }
  
}
