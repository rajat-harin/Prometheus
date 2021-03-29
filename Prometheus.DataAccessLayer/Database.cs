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
