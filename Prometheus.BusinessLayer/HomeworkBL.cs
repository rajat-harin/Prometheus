using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.BusinessLayer.Models;
using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;

namespace Prometheus.BusinessLayer
{
    public class HomeworkBL
    {
        HomeworkRepo HWRepo = new HomeworkRepo();
        CourseRepo courseRepo = new CourseRepo();
        AssignmentRepo assignmentRepo = new AssignmentRepo();
        AssignedHomework assignedcourse = new AssignedHomework();

        bool HwAdded = false;
        public bool ValidateHomework(Homework homework)
        {
            StringBuilder sb = new StringBuilder();
            bool validHomework = true;
            if (homework.Deadline == System.DateTime.Now)
            {
                validHomework = false;
                sb.Append(Environment.NewLine + "Deadline cannot occur the created Date");
            }
            /*int result = DateTime.Compare(homework.Deadline, homework.ReqTime);
            if (result > 0 )
            {
                sb.Append(Environment.NewLine + "Required cannot be Less than DeadLine");
            }*/
            if (validHomework == false)
                throw new PrometheusException(sb.ToString());
            return validHomework;
        }

        //Add Homework
        public bool AddHomeworkBL(Homework newHomework)
        {
            try
            {
                if (ValidateHomework(newHomework))
                {
                    HwAdded = HWRepo.AddHomework(newHomework);
                }
            }
            catch
            {
                throw;
            }
            return HwAdded;
        }
        public bool AssignedHomework(AssignedHomework objModelClass)
        {
            bool isAssigned = false;
            try
            {
                if (HwAdded)
                {
                    isAssigned = new AssignmentRepo().AddAssignment(new Assignment
                    {
                        HomeWorkID = objModelClass.HomeworkID,
                        CourseID = objModelClass.CourseID,
                        TeacherID = objModelClass.TeacherID
                    });
                }
            }
            catch
            {
                throw;
            }
            return isAssigned;
        }

        public List<AssignedHomework> SearchHomeworkByID(int homeworkId, int courseId)
        {
            try
            {
                List<Assignment> assignmentList = assignmentRepo.GetAllAssignments();
                List<Homework> homeworkList = HWRepo.GetAllHomework();//Creating the collection over Entity

                //as we need to create list, we need collection that will only be generated from object
                var result = assignmentList.Where(
                    item => item.HomeWorkID == homeworkId &&
                    item.CourseID == courseId
                ).Join(
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
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Homeworks Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AssignedHomework> GetAllHomeworks()
        {
            try
            {
                List<Assignment> assignmentList = assignmentRepo.GetAllAssignments();
                List<Homework> homeworkList = HWRepo.GetAllHomework();//Creating the collection over Entity

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
                            Deadline = homework.Deadline,
                            ReqTime = homework.ReqTime,
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
                    throw new PrometheusException("No Homeworks Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool updateHomework(Homework homework)
        {
            try
            {
                if (homework.HomeworkID != 0)
                {
                    if (HWRepo.UpdateHomework(homework))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deleteHomework_Assignment(int HomeworkId, int AssignmentID)
        {
            try
            {
                bool isHwDeleted = HWRepo.DeleteHomework(HomeworkId);
                if (isHwDeleted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
