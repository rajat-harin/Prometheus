using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.DataAccessLayer
{
    public class Database
    {
        // STORED PROCEDURE NAMES
        // TODO: Create const string for STORED PROCEDURE Names here
        //Stored Procedures related to User
        public const string USERLOGIN = "UserLogin";
        public const string USERUPDATEPASSWORD = "UserUpdatePassword";
        public const string GETALLUSERS = "GetAllUsers";
        public const string GETUSERBYID = "SearchUser";
        public const string DELETEUSER = "DeleteUser";
        public const string INSERTCOURSE = "InsertCourse";
        public const string INSERTSTUDENT = "InsertStudent";
        public const string INSERTUSER = "InsertUser";
        public const string INSERTTEACHER = "InsertTeacher";
        public const string UPDATETEACHER = "UpdateTeacher";
        public const string GETTEACHERS = "GetTeachers";
        public const string GETTEACHERBYID = "GetTeacherByUserID";
        public const string GETSTUDENTS = "GetStudents";
        public const string GETSTUDENTSBYID = "GetStudentByUserID";
        public const string DELETETEACHER = "DeleteTeacher";


        //Stored Procedures related to Student
        //public const string INSERTSTUDENT = "AddNewCourse";
        public const string UPDATESTUDENT = "UpdateStudent";
        public const string DELETESTUDENT = "DeleteStudent";
        //public const string GETSTUDENTS = "GetStudents";
        public const string SEARCHSTUDENT = "SearchStudent";
        public const string GETCOURSESOFSTUDENT = "GetCoursesOfStudent";

        //Stored Procedures related to Course
        public const string GETCOURSES = "GetCourses";
        //public const string INSERTCOURSE = "InsertCourse";
        public const string UPDATECOURSE = "UpdateCourse";
        public const string DELETECOURSE = "DeleteCourse";
        public const string GETCOURSEBYID = "GetCourseById";

        //Stored Procedures related to Enrollment
        public const string ADDENROLLMENT = "AddEnrollment";
        public const string UPDATEENROLLMENT = "UpdateEnrollment";
        public const string DELETEENROLLMENT = "DeleteEnrollment";
        public const string GETENROLLMENTS = "GetEnrollments";
        public const string GETENROLLMENTBYID = "GetEnrollmentById";

        //Stored Procedures related to Homework
        public const string GETASSIGNEDHOMEWORK = "GetAssignedHomework";

        //Stored Procedures related to HomeworkPlan
        public const string GETHOMEWORKPLAN = "GetHomeworkPlan";
        public const string GETHOMEWORKPLANBYKEY = "GetHomeworkPlanByKey";
        public const string ADDHOMEWORKPLAN = "AddHomeworkPlan";
        public const string UPDATEHOMEWORKPLAN = "UpdateHomeworkPlan";
        public const string DELETEHOMEWORKPLAN = "DeleteHomeworkPlan";
        public const string DELETEHOMEWORKPLANFORSTUDENT = "DeleteHomeworkPlanForStudent";


        // this field returns connection string from App.config
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["prometheusDb"].ConnectionString;
            }
        }
    }
}
