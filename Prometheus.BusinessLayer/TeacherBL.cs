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

        //Make function for adding courseID and TeacherID in the Teaches Table
        //I have created function in TeacherRepo, Xaml file is created but having the issue
        //in check boxes , after clicking checkbox in select course the teacher id and course id will be entered
        //into teaches table and after clicking on mycourses it should shows the courses information of teacher

    }
  
}
