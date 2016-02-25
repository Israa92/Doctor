using System;
using System.Linq;

namespace DoctorServer
{
    class DatabaseConnections
    {
        DoctorEntities db = new DoctorEntities();
        User user = new User();
       
        public bool IsUserRegisterad(string email)
        {

            return db.User.Any(i => i.Email == email);

        }
        public void UserRegister(string username, string email, int age, string password)
        {
            if (!IsUserRegisterad(email))
            {
                username = user.UserName;
                email = user.Email;
                age = user.Age;
                password = user.Password;
                db.User.Add(user);
                db.SaveChanges();

            }
            else
                Console.WriteLine("Use other Username or email to register");

        }
        public bool IsUserLoggedIn(string email)
        {
            return db.User.Any(i => i.Email == email);
        }

        public void UserLoggedIn(string email, string password)
        {
            if (IsUserLoggedIn(email))
            {
                email = user.Email;
                password = user.Password;

                db.User.Add(user);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Email not exist");
            }
        }
    }
}

