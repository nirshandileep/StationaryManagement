using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using CommonTier;
using System.Data;

namespace DataTier.Branch
{
    public class BranchDAO
    {
        internal static bool Insert(Branch branch, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Branch_Insert);

                db.AddInParameter(cmd, "BranchName", DbType.String, branch.BranchName);
                db.AddInParameter(cmd, "AddressLine1", DbType.String, branch.AddressLine1);
                db.AddInParameter(cmd, "AddressLine2", DbType.String, branch.AddressLine2);
                db.AddInParameter(cmd, "AddressLine3", DbType.String, branch.AddressLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, branch.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, branch.Email);
                db.AddInParameter(cmd, "MainBranchID", DbType.Int32, branch.MainBranchID);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, branch.IsActive);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, 1);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    branch.BranchID = newID;
                    rslt = true;
                }
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        internal static List<Branch> GetAll(Branch srchBranch, string executedBy)
        {
            List<Branch> branchList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Branch_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, srchBranch.IsActive);
                db.AddInParameter(cmd, "BranchName", DbType.String, srchBranch.BranchName);
                db.AddInParameter(cmd, "AddressLine1", DbType.String, srchBranch.AddressLine1);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    branchList = Utility.DataTableToCollection<Branch>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                branchList = null;
            }

            return branchList;
        }

        internal static bool Update(Branch branch, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Branch_Update);

                db.AddInParameter(cmd, "BranchID", DbType.Int32, branch.BranchID);
                db.AddInParameter(cmd, "BranchName", DbType.String, branch.BranchName);
                db.AddInParameter(cmd, "AddressLine1", DbType.String, branch.AddressLine1);
                db.AddInParameter(cmd, "AddressLine2", DbType.String, branch.AddressLine2);
                db.AddInParameter(cmd, "AddressLine3", DbType.String, branch.AddressLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, branch.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, branch.Email);
                db.AddInParameter(cmd, "MainBranchID", DbType.Int32, branch.MainBranchID);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, branch.IsActive);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, 1);

                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        internal static bool Delete(int branchID, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Branch_Delete);

                db.AddInParameter(cmd, "BranchID", DbType.Int32, branchID);
                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        internal static Branch GetById(int branchID, string executedBy)
        {
            Branch branch = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Branch_Select_By_Id);

                db.AddInParameter(cmd, "BranchID", DbType.Int32, branchID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    branch = Utility.DataTableToCollection<Branch>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                branch = null;
            }

            return branch;
        }
    }
}
