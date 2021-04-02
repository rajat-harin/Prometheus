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
        public string UserID{ get; set; }
        public string IsAdmin { get; set; }
        
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
            IsAdmin = String.Empty;
        }
    }
}
