using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.User
{
    public class UserManager
    {

        public static bool AddUser(User user, int executedBy)
        {
            if (UserDAO.CheckUsernameExist(user.UserName, executedBy) == false)
            {
                return UserDAO.Insert(user, executedBy);
            }
            else
            {
                return false;
            }
        }

        public static bool EditUser(User user, int executedBy)
        {
            return UserDAO.Update(user, executedBy);
        }

        public static bool Delete(User user, int executedBy)
        {
            return UserDAO.Delete(user, executedBy);
        }

        public static bool ValidateUser(string userName, string password, int executedBy, out int userId)
        {
            User user = new User() { UserName = userName, Password = password };
            bool success = UserDAO.Authenticate(user, executedBy);
            userId = user.UserID;
            return success;
        }

        public static List<User> SearchUsers(User user, int executedBy)
        {
            return UserDAO.GetAll(user, executedBy);
        }

        public static User GetUserByUserID(int userId, int executedBy)
        {
            return UserDAO.GetById(userId, executedBy);
        }
    }
}
