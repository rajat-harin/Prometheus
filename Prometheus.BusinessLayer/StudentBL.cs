using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;

namespace Prometheus.BusinessLayer
{
    public class StudentBL
    {
        //Get List of Courses in which student is Enrolled
        public List<object> GetCoursesByStudentID(int id)
        {
            /*
            List<Student> StudentCoursesList = new List<Student>();
            try
            {
                MyCoursesTable =  new StudentRepo().GetMyCourses(id).Tables[0];
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }

            return MyCoursesTable;
            /
            */
            EnrollmentRepo enrollmentRepo = new EnrollmentRepo();
            List<Enrollment> enrollments = enrollmentRepo.GetEnrollments();
            CourseRepo courseRepo = new CourseRepo();
            List<Course> courses = courseRepo.GetCourses();

            var result = enrollments.Join(
                courses,
                enrollment => enrollment.CourseID,
                course => course.CourseID,
                (enrollment, course) => new 
                {
                    EnrollmentID = enrollment.EnrollmentID,
                    CourseID = enrollment.CourseID,
                    Name = course.Name,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate
                }
                ).Cast<object>().ToList();
            return result;
        }

        // Can be moved to CourseBL
        // Returns List of Courses
        public List<Course> GetCoursesAsList()
        {
            List<Course> CourseList;
            try
            {
                CourseList = new CourseRepo().GetCourses();
            }
            catch (Exception ex)
            {

                throw new PrometheusException(ex.Message);
            }
            return CourseList;
        }

        //Method to Enroll a student is a course
        public bool EnrollInCourse(string studentId, int courseId)
        {
            bool isEnrolled = false;
            try
            {
                StudentRepo studentDAL = new StudentRepo();
                int sId;
                if(!Int32.TryParse(studentId, out sId))
                {
                    throw new PrometheusException("Invalid Student ID!");
                }

                isEnrolled = new EnrollmentRepo().Insert(new Enrollment
                {
                    StudentID = sId,
                    CourseID = courseId
                }) ;
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
