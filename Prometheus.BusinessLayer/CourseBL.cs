using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.BusinessLayer.Models;

namespace Prometheus.BusinessLayer
{
    public class CourseBL
    {
        CourseRepo courseRepo = new CourseRepo();
        TeacherRepo teacherRepo = new TeacherRepo();
        public bool AddNewCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    CourseRepo courseRepo = new CourseRepo();
                    if (courseRepo.InsertCourse(course))
                    {
                        return true;
                    }
                    else
                    {
                        throw new PrometheusException("Insertion of Course Failed");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }

        public List<Course> GetCourses()
        {
            List<Course> courseList;
            try
            {
                courseList = new CourseRepo().GetCourses();
                if (courseList.Any())
                {
                    return courseList;
                }
                else
                {
                    throw new PrometheusException("No Courses Found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Course> GetCourseByName(string name)
        {
            try
            {
                CourseRepo courseRepo = new CourseRepo();
                List<Course> courses = courseRepo.GetCourses();

                var result = courses.Where(item => item.Name == name).ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Course Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
