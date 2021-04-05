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

        /*public List<TeacherCourses> GetCourses(Teacher teacher, int courseId)
        {
            try
            {
                //Teaches ki Entity, Repo me Addteaches, searchteaches,deleteteaches,updateteaches,getall
                //bl me ky karna ki addteaches ka function banana and bs teacher id lake de baki krti mai 
                //teacherid and courseid dodno depend karta age bye
                List<Course> courseList = courseRepo.GetCourses();
                List<Teacher> teacherList = teacherRepo.TeacherCourses(teacher.TeacherID, courseId);//Creating the collection over Entity

                //as we need to create list, we need collection that will only be generated from object
                /*var result = courseList.Where(
                    item => item.CourseID == courseId
                    ),
                        (teacher) => new AssignedHomework
                        {
                            AssignmentID = assignment.AssignmentID,
                            TeacherID = assignment.TeacherID,
                            CourseID = assignment.CourseID,
                            HomeworkID = homework.HomeworkID,
                            Description = homework.Description,
                            LongDescription = homework.LongDescription
                        }
                    ).ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new Exception("No Homeworks Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        }
        */
