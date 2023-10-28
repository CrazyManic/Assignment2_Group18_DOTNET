using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public class Validation
    {
        public bool isValidName(string name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, "^[a-zA-Z]+$");

        }
        public bool isValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z]+\.[a-zA-Z]+$");

        }
        public bool isValidUsername(string username)
        {
            return  System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z]+[0-9]+$");

        }
    }
}
