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
        public List<AssignedHomework> GetAssignedHomework(int id)
        {
            try
            {
                List<EnrolledCourse> enrolledCourses = GetCoursesByStudentID(id);
                List<Assignment> assignments = new AssignmentRepo().GetAllAssignment();
                List<Homework> homeworks = new HomeworkRepo().GetAllHomework();

                var result = from course in enrolledCourses
                             join assignment in assignments
                             on course.CourseID equals assignment.CourseID
                             join homework in homeworks
                             on assignment.HomeWorkID equals homework.HomeworkID
                             select new AssignedHomework
                             {
                                 AssignmentID = assignment.AssignmentID,
                                 Description = homework.Description,
                                 Deadline = homework.Deadline,
                                 ReqTime = homework.ReqTime,
                                 LongDescription = homework.LongDescription,
                                 CourseName = course.Name,
                                 HomeworkID = homework.HomeworkID
                             };
                if(result.Any())
                {
                    return result.ToList();
                }
                else
                {
                    throw new PrometheusException("No Assignments Found !");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ExtendedHomeworkPlan> GetExtendedHomeworkPlan(int id)
        {
            try
            {
                
                List<Assignment> assignments = new AssignmentRepo().GetAllAssignment();
                List<Homework> homeworks = new HomeworkRepo().GetAllHomework();
                List<HomeworkPlan> homeworkPlans = new HomeworkPlanRepo().GetHomeworkPlans()
                    .Where(homeworkPlan=> homeworkPlan.StudentID == id).ToList();

                var result = from plan in homeworkPlans
                             join homework in homeworks
                             on plan.HomeworkID equals homework.HomeworkID
                             select new ExtendedHomeworkPlan
                             {
                                 HomeworkID = homework.HomeworkID,
                                 Description = homework.Description,
                                 Deadline = homework.Deadline,
                                 ReqTime = homework.ReqTime,
                                 PriorityLevel = plan.PriorityLevel,
                                 isCompleted = plan.isCompleted
                             };

                if (result.Any())
                {
                    return result.ToList();
                }
                else
                {
                    throw new PrometheusException("No Plans Found!");
                    //DeviseHomeworkPlanByDeadline(id);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddHomeworkPlan(HomeworkPlan plan)
        {
            try
            {
                if(plan != null)
                {
                    HomeworkPlanRepo homeworkPlanRepo = new HomeworkPlanRepo();
                    if (homeworkPlanRepo.Insert(plan))
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
        public void DeviseHomeworkPlanByDeadline(int id)
        {
            try
            {
                HomeworkPlanRepo homeworkPlanRepo = new HomeworkPlanRepo();
                homeworkPlanRepo.DeleteAll(id);
                List<AssignedHomework> assignedHomeworks = GetAssignedHomework(id);
                //List<HomeworkPlan> homeworkPlans = new HomeworkPlanRepo().GetHomeworkPlans()
                //    .Where(homeworkPlan => homeworkPlan.StudentID == id).ToList();
                int count = assignedHomeworks.Count;
                var result = assignedHomeworks.OrderBy(homework => homework.Deadline).Select(homework => new HomeworkPlan
                {
                    StudentID = id,
                    HomeworkID = homework.HomeworkID,
                    PriorityLevel = count--,
                    isCompleted = false
                }).ToList();

                foreach(var item in result)
                {
                    AddHomeworkPlan(item);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

/*
 * HomeworkID = homework.HomeworkID,
                    Description = homework.Description,
                    ReqTime = homework.ReqTime,
                    Deadline = homework.Deadline,
                    StudentID = id,
                    PriorityLevel = count--,
                    isCompleted = false
 */