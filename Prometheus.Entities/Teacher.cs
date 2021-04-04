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
        public string UserID { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set;}
        public bool IsAdmin { get; set; }

       public Teacher()
        {
            TeacherID = 0;
            FName = String.Empty;
            LName = String.Empty;
            UserID = String.Empty;
            Address = String.Empty;
            DOB = DateTime.Now;
            City = String.Empty;
            MobileNo = String.Empty;
            IsAdmin = false;
        }

        

        
        public Teacher(int id, string fName, string lName, string userName, string address, DateTime dOB, string city, string mobileNo, bool isAdmin)
        {
            TeacherID = id;
            FName = fName;
            LName = lName;
            UserID = userName;
            Address = address;
            DOB = dOB;
            City = city;
            MobileNo = mobileNo;
            IsAdmin = isAdmin;
        }
    }
}
