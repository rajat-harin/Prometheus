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

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; }
    }
}
