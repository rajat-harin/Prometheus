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
    public class TeachesBL
    {
        public bool AddTeaches(Teacher teacher,int courseId)
        {
            try
            {
                if (teacher != null)
                {
                    TeacherRepo userRepo = new TeacherRepo();
                    
                   /* CourseRepo studentRepo = new CourseRepo();*/
                    Teacher user = new Teacher { TeacherID = teacher.TeacherID };

                    if (userRepo.InsertTeacher(user))
                    {
                        TeachesRepo teachesRepo = new TeachesRepo();
                        teachesRepo.InsertTeaches(TeacherID, courseId);

                        return true;
                        var result = assignmentList.Join(
                    homeworkList,
                    assignment => assignment.HomeWorkID,
                    homework => homework.HomeworkID,
                    (assignment, homework) => new AssignedHomework
                    {
                        AssignmentID = assignment.AssignmentID,
                        TeacherID = assignment.TeacherID,
                        CourseID = assignment.CourseID,
                        HomeworkID = homework.HomeworkID,
                        Description = homework.Description,
                        LongDescription = homework.LongDescription
                    }
                ).ToList();
                    }
                    else
                    {

                        throw new PrometheusException("Student registration failed");
                    }
                    }
                    else
                    {
                        throw new PrometheusException("Student registration failed");
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
