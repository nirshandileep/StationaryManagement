using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using CommonTier;
using System.Data;

namespace DataTier.User
{
    public class UserDAO
    {
        public static bool Authenticate(User user, int executedBy)
        {
            bool success = true;

            try
            {

                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand dbCommand = db.GetStoredProcCommand(Constants.SP_User_Check_Login);

                db.AddInParameter(dbCommand, "UserName", DbType.String, user.UserName);
                db.AddInParameter(dbCommand, "Password", DbType.String, user.Password);

                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    user = Utility.DataTableToCollection<User>(ds.Tables[0]).FirstOrDefault();
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public static bool Insert(User user, int executedBy)
        {
            bool success = true;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_Insert);

                db.AddInParameter(cmd, "RoleID", DbType.Int32, user.RoleID);
                db.AddInParameter(cmd, "UserName", DbType.String, user.UserName);
                db.AddInParameter(cmd, "Password", DbType.String, user.Password);
                db.AddInParameter(cmd, "Email", DbType.String, user.Email);
                db.AddInParameter(cmd, "RemainAttempts", DbType.Int32, user.RemainAttempts);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, user.IsActive);
                db.AddInParameter(cmd, "IsLocked", DbType.Boolean, user.IsLocked);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, 1);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    user.UserID = newID;
                    success = true;
                }
            }

            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public static bool Update(User user, int executedBy)
        {
            bool success = true;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_Update);

                db.AddInParameter(cmd, "UserID", DbType.Int32, user.UserID);
                db.AddInParameter(cmd, "RoleID", DbType.Int32, user.RoleID);
                db.AddInParameter(cmd, "UserName", DbType.String, user.UserName);
                db.AddInParameter(cmd, "Password", DbType.String, user.Password);
                db.AddInParameter(cmd, "Email", DbType.String, user.Email);
                db.AddInParameter(cmd, "RemainAttempts", DbType.Int32, user.RemainAttempts);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, user.IsActive);
                db.AddInParameter(cmd, "IsLocked", DbType.Boolean, user.IsLocked);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, 1);

                db.ExecuteNonQuery(cmd);
            }

            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        public static bool Delete(User user, int executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_Delete);

                db.AddInParameter(cmd, "UserID", DbType.Int32, user.UserID);

                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        public static User GetById(int userId, int executedBy)
        {
            User user = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_Select);

                db.AddInParameter(cmd, "UserID", DbType.Int32, userId);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    user = Utility.DataTableToCollection<User>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                user = null;
            }

            return user;

        }

        public static bool CheckUsernameExist(string username, int executedby)
        {
            bool success = true;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_Insert);

                db.AddInParameter(cmd, "UserName", DbType.String, username);
                db.AddOutParameter(cmd, "IsExists", DbType.Boolean, 4);

                db.ExecuteNonQuery(cmd);

                bool exist = false;
                bool.TryParse(db.GetParameterValue(cmd, "IsExists").ToString(), out exist);

                success = exist;
            }

            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public static List<User> GetAll(User uesr, int executecBy)
        {
            List<User> userList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_User_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, uesr.IsActive);
                db.AddInParameter(cmd, "UserName", DbType.String, uesr.UserName);
                db.AddInParameter(cmd, "RoleID", DbType.Int32, uesr.RoleID);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    userList = Utility.DataTableToCollection<User>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                userList = null;
            }

            return userList;

        }
    }
}
