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
    public class TeacherBL
    {
        public Teacher GetTeacher(string userID)
        {

            try
            {
                TeacherRepo teacherRepo = new TeacherRepo();
                List<Teacher> teachers = teacherRepo.GetTeachers();
                if (teachers.Any())
                {
                    Teacher result = teachers.SingleOrDefault(item => item.UserID == userID);
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Teachers Found");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
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

        public List<TeacherCourses> GetCoursesByTeacherID(int id)
        {
            try
            {
                TeachesRepo teachesRepo = new TeachesRepo();
                List<Teaches> teachesList = teachesRepo.GetAllTeaches();
                CourseRepo courseRepo = new CourseRepo();
                List<Course> courses = courseRepo.GetCourses();

                var result = teachesList.Where(item => item.TeacherID == id).Join(
                    courses,
                    teaches => teaches.CourseID,
                    course => course.CourseID,
                    (teaches, course) => new TeacherCourses
                    {
                        TeacherID = id,
                        CourseID = teaches.CourseID,
                        Name = course.Name,
                        StartDate = course.StartDate,
                        EndDate = course.EndDate
                    }
                    ).ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Enrollments Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Make function for adding courseID and TeacherID in the Teaches Table
        //I have created function in TeacherRepo, Xaml file is created but having the issue
        //in check boxes , after clicking checkbox in select course the teacher id and course id will be entered
        //into teaches table and after clicking on mycourses it should shows the courses information of teacher

    }
  
}
