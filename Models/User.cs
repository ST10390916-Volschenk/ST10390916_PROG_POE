//ST10390916
//All work is my own unless otherwise cited or referenced.

using ST10390916_PROG_POE.Data;

namespace ST10390916_PROG_POE.Models
{

    public enum Role
    {
        Manager,
        Lecturer
    }
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role UserRole { get; set; }


        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="user"></param>
        public string AddNewUser(User user)
        {
            AppDbContext context = new AppDbContext();
            string msg = "";

            if (context.users.Where(e => e.Email.Equals(user.Email)) != null)
            {
                context.users.Add(user);
                context.SaveChanges();
            }
            else
            {
                msg = $"An account with {user.Email} already exists.";
            }

            return msg;
        }

        /// <summary>
        /// Checks if the user exists in the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public int CheckUser(string email, string password)
        {
            int userID = -1;
            AppDbContext context = new AppDbContext();
            User? user = context.users.Where(e => e.Email.Equals(email)).SingleOrDefault();
            if ((user != null) && (user.Password == password))
            {
                userID = user.UserID;
            }

            return userID;
        }

        /// <summary>
        /// Searches for a user in the database
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User GetUser(int userID)
        {
            AppDbContext context = new AppDbContext();
            User user = context.users.Find(userID);
            return user;
        }

    }



}
