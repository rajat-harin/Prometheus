using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    //Class for entity : STUDENT 
    public class Student
    {
        public int StudentID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }

        public Student()
        {
            StudentID = 0;
            FName = String.Empty;
            LName = String.Empty;
            UserName = String.Empty;
            Address = String.Empty;
            DOB = DateTime.Now;
            City = String.Empty;
            Password = String.Empty;
            MobileNo = String.Empty;
        }
        public Student(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Student(int id, string fName, string lName, string userName, string address, DateTime dOB, string city, string password, string mobileNo)
        {
            StudentID = id;
            FName = fName;
            LName = lName;
            UserName = userName;
            Address = address;
            DOB = dOB;
            City = city;
            Password = password;
            MobileNo = mobileNo;
        }
    }
}
