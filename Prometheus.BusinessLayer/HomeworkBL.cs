using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;

namespace Prometheus.BusinessLayer
{
    public class HomeworkBL
    {
        HomeworkRepo HWRepo = new HomeworkRepo();
        public bool ValidateHomework(Homework homework)
        {
            StringBuilder sb = new StringBuilder();
            bool validHomework = true;
            if (homework.Deadline == System.DateTime.Now)
            {
                validHomework = false;
                sb.Append(Environment.NewLine + "Deadline cannot occur the created Date");

            }
            if (homework.Description == string.Empty)
            {
                validHomework = false;
                sb.Append(Environment.NewLine + "Description Required");

            }
            if (validHomework == false)
                throw new Exception(sb.ToString());// when it is not false then handle by this way also
            return validHomework;
        }

        //Add Homework
        public bool AddHomeworkBL(Homework newHomework)
        {
            bool HwAdded = false;
            try
            {
                if (ValidateHomework(newHomework))
                {
                    HwAdded = HWRepo.AddHomework(newHomework);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return HwAdded;
        }

        public Homework SearchHomeworkById(int homeworkId)
        {
            //List<Homework> homeworks = HWRepo.SearchHomework(homeworkId);
            Homework homework = HWRepo.SearchHomework(homeworkId);
            //check your object is null or not
            return homework;
        }









        /*EnrollmentRepo enrollmentRepo = new EnrollmentRepo();
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
            return result;*/
    }
}
