using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.BusinessLayer.Models;
using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;

namespace Prometheus.BusinessLayer
{
    public class StudentBL
    {
        //Get List of Courses in which student is Enrolled
        public List<EnrolledCourse> GetCoursesByStudentID(int id)
        {
            try
            {
                EnrollmentRepo enrollmentRepo = new EnrollmentRepo();
                List<Enrollment> enrollments = enrollmentRepo.GetEnrollments();
                CourseRepo courseRepo = new CourseRepo();
                List<Course> courses = courseRepo.GetCourses();

                var result = enrollments.Where(item => item.StudentID == id).Join(
                    courses,
                    enrollment => enrollment.CourseID,
                    course => course.CourseID,
                    (enrollment, course) => new EnrolledCourse
                    {
                        EnrollmentID = enrollment.EnrollmentID,
                        CourseID = enrollment.CourseID,
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

        // Can be moved to CourseBL
        // Returns List of Courses
        public List<Course> GetCoursesAsList()
        {
            List<Course> CourseList;
            try
            {
                CourseList = new CourseRepo().GetCourses();
                if(CourseList.Any())
                {
                    return CourseList;
                }
                else
                {
                    throw new PrometheusException("No Courses Found!");
                }
            }
            catch (Exception ex)
            {

                throw new PrometheusException(ex.Message);
            }
        }

        //Method to Enroll a student is a course
        public bool EnrollInCourse(string studentId, int courseId)
        {
            bool isEnrolled = false;
            try
            {
                StudentRepo studentDAL = new StudentRepo();
                int sId;
                if(string.IsNullOrEmpty(studentId))
                {
                    if (!Int32.TryParse(studentId, out sId))
                    {
                        throw new PrometheusException("Invalid Student ID!");
                    }
                    isEnrolled = new EnrollmentRepo().Insert(new Enrollment
                    {
                        StudentID = sId,
                        CourseID = courseId
                    });
                }
                    
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return isEnrolled;
        }
        //Method to Get Assigned Homework
        /*
        public DataTable GetAssignedHomework(int id)
        {
            DataTable MyCoursesTable = new DataTable();
            try
            {
                MyCoursesTable = new StudentRepo().GetAssignedHomework(id).Tables[0];
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }

            return MyCoursesTable;

        }
        */
    }
}
