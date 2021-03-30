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
        //Stored Procedures related to Student
        public const string INSERTSTUDENT = "InsertStudent";
        public const string UPDATESTUDENT = "UpdateStudent";
        public const string DELETESTUDENT = "DeleteStudent";
        public const string GETSTUDENTS = "GetStudents";
        public const string SEARCHSTUDENT = "SearchStudent";
        public const string GETCOURSESOFSTUDENT = "GetCoursesOfStudent";

        //Stored Procedures related to Course
        public const string GETCOURSES = "GetCourses";

        //Stored Procedures related to Enrollment
        public const string ADDENROLLMENT = "AddEnrollment";

        //Stored Procedures related to Homework
        public const string GETASSIGNEDHOMEWORK = "GetAssignedHomework";



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
