using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorServer
{
    class DatabaseConnections
    {
        DoctorEntities db = new DoctorEntities();
        User user = new User();
        public bool IsUserRegistered(string username)
        {
            return db.User.Any(i => i.UserName == username);
        }
        public void UserReg(string username, string email, string password, int age)
        {
            if (IsUserRegistered(username))
            {
                username = user.UserName;
                email = user.Email;
                password = user.Password;
                age = user.Age;

                db.User.Add(user);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("The username or email is already existed"); 
            }
        }
    }
}
