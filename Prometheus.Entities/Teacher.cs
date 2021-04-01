using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }

        public string UserID { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public Teacher()
        {
            TeacherID = 0;
            DOB = DateTime.Now;
            FName = string.Empty;
            LName = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            MobileNo = string.Empty;
            UserID = string.Empty;
            isAdmin = false;

        }
        public Teacher(int id, string fName, string lName, string userName, string address, DateTime dOB, string city, string mobileNo)
        {
            TeacherID = id;
            FName = fName;
            LName = lName;
            UserID = userName;
            Address = address;
            DOB = dOB;
            City = city;
            MobileNo = mobileNo;
        }
    }
}
