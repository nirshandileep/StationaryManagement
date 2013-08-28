using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using CommonTier;
using System.Data;

namespace DataTier.Package
{
    public class PackageDAO
    {
        public static List<Package> GetAll(Package srchPackage, string executedBy)
        {
            List<Package> cusList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Package_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, srchPackage.IsActive);
                db.AddInParameter(cmd, "PackageCode", DbType.String, srchPackage.PackageCode);
                db.AddInParameter(cmd, "PackageName", DbType.String, srchPackage.PackageName);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    cusList = Utility.DataTableToCollection<Package>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                cusList = null;
            }

            return cusList;

        }

        public static bool Insert(Package package, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Package_Insert);

                db.AddInParameter(cmd, "ItemID", DbType.Int32, package.ItemID);
                db.AddInParameter(cmd, "QtyPerPack", DbType.Int32, package.QtyPerPack);
                db.AddInParameter(cmd, "PackageCode", DbType.String, package.PackageCode);
                db.AddInParameter(cmd, "PackageName", DbType.String, package.PackageName);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, package.IsActive);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, 1);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    rslt = true;
                    package.PackageID = newID;
                }
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static bool Update(Package package, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Package_Update);

                db.AddInParameter(cmd, "PackageID", DbType.Int32, package.PackageID);
                db.AddInParameter(cmd, "QtyPerPack", DbType.Int32, package.QtyPerPack);
                db.AddInParameter(cmd, "PackageName", DbType.String, package.PackageName);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, package.IsActive);
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

        public static bool Delete(int packageID, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Package_Delete);

                db.AddInParameter(cmd, "PackageID", DbType.String, packageID);

                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static Package GetById(int packageID, string executedBy)
        {
            Package supplier = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Package_Select);

                db.AddInParameter(cmd, "PackageID", DbType.Int32, packageID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    supplier = Utility.DataTableToCollection<Package>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                supplier = null;
            }

            return supplier;

        }
    }
}
