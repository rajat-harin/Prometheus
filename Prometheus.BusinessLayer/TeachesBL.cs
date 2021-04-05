using Prometheus.BusinessLayer.Models;
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
        public bool AddTeaches(Course course,int teacherID)
        {
            try
            {
                if (course != null)
                {
                    TeacherRepo userRepo = new TeacherRepo();
                    
                   /* CourseRepo studentRepo = new CourseRepo();*/
                    //Teacher user = new Teacher { TeacherID = teacher.TeacherID };
                    TeachesRepo teachesRepo = new TeachesRepo();
                   teachesRepo.InsertTeaches(teacherID,course.CourseID);     
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
        public bool AddTeachesList(List<SelectedCourse> selecteedCourses, int teacherID)
        {
            try
            {
                bool flag = true;
                List<Course> courses = new List<Course>();
                if (selecteedCourses.Any())
                {
                    selecteedCourses.ForEach(item =>
                   {
                       Course course = new Course
                       {
                           CourseID = item.CourseID,
                           StartDate = item.StartDate,
                           EndDate = item.EndDate,
                           Name = item.Name
                       };
                       courses.Add(course);
                   });

                    foreach (Course item in courses)
                    {
                        if(!flag)
                        {
                            break;
                        }
                        flag = AddTeaches(item, teacherID);
                    }
                    if(flag)
                    {
                        return true;
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
