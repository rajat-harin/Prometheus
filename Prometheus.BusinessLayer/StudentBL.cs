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
        public DataTable GetMyCourses(int id)
        {
            DataTable MyCoursesTable = new DataTable();
            try
            {
                MyCoursesTable =  new StudentDAL().GetMyCourses(id).Tables[0];
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }

            return MyCoursesTable;
                       
        }

        // Can be moved to CourseBL
        // Returns List of Courses
        public List<Course> GetCoursesAsList()
        {
            List<Course> CourseList = new List<Course>();
            DataTable CourseDT = new DataTable();
            try
            {
                CourseDT = new CourseDAL().GetCourses().Tables[0];
            }
            catch (Exception ex)
            {

                throw new PrometheusException(ex.Message);
            }
            
            var result = from course in CourseDT.AsEnumerable()
                         select course;
            foreach (var item in result)
            {
                CourseList.Add(
                    new Course(
                        item.Field<int>("CourseID"),
                        item.Field<string>("Name"),
                        item.Field<DateTime>("StartDate"),
                        item.Field<DateTime>("EndDate")
                    )
                );
            }
            return CourseList;
        }

        //Method to Enroll a student is a course
        public bool EnrollInCourse(string studentId, int courseId)
        {
            bool isEnrolled = false;
            try
            {
                StudentDAL studentDAL = new StudentDAL();
                int sId;
                if(!Int32.TryParse(studentId, out sId))
                {
                    throw new PrometheusException("Invalid Student ID!");
                }

                isEnrolled =  studentDAL.EnrollStudentInCourse(sId,courseId);
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }
            return isEnrolled;
        }
        //Method to Get Assigned Homework
        public DataTable GetAssignedHomework(int id)
        {
            DataTable MyCoursesTable = new DataTable();
            try
            {
                MyCoursesTable = new StudentDAL().GetAssignedHomework(id).Tables[0];
            }
            catch (Exception ex)
            {
                throw new PrometheusException(ex.Message);
            }

            return MyCoursesTable;

        }
    }
}
