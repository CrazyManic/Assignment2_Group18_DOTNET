using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IUserManager
    {
        List<User> GetUsers(); //returns a list of all users in the database
        User CreateUser(string username, string password, string email, string FirstName, string LastName); //creates 1 user in the database data requirements NOT FINALIZED ALI!!!! Usernames MUST be UNIQUE!
        User GetUserById(int userId); //returns a singlue user with matching ID.
        User GetUserByUsername(string username); // return a single user with matching  username
        User Login(string username, string password); //returns a single user with matching userName and Password.
        void Update(string username, string password, string email, string FirstName, string LastName); // updates user credentials according to input fields.data requirements NOT FINALIZED ALI!!!!
    }
}
