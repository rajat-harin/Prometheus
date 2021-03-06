using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    //Class for entity : USER
    public class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public User()
        {
            UserID = String.Empty;
            Password = String.Empty;
            Role = String.Empty;
            SecurityQuestion = String.Empty;
            SecurityAnswer = String.Empty;
        }
        public User(string userId, string password)
        {
            UserID = userId;
            Password = password;
        }
        public User(string userId, string password, string role)
        {
            UserID = userId;
            Password = password;
            Role = role;
        }
        public User(string userId, string password, string role, string securityQuestion, string securityAnswer)
        {
            UserID = userId;
            Password = password;
            Role = role;
            SecurityQuestion = securityQuestion;
            SecurityAnswer = securityAnswer;
        }
    }
}
