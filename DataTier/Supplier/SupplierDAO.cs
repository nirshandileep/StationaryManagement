using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using CommonTier;
using System.Data;

namespace DataTier.Supplier
{
    public class SupplierDAO
    {
        public static List<Supplier> GetAll(Supplier srchSupplier, string executedBy)
        {
            List<Supplier> cusList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, srchSupplier.IsActive);
                db.AddInParameter(cmd, "SupplierName", DbType.String, srchSupplier.SupplierName);
                db.AddInParameter(cmd, "AddresssLine1", DbType.String, srchSupplier.AddresssLine1);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    cusList = Utility.DataTableToCollection<Supplier>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                cusList = null;
            }

            return cusList;

        }

        public static bool Insert(Supplier supplier, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_Insert);

                db.AddInParameter(cmd, "SupplierName", DbType.String, supplier.SupplierName);
                db.AddInParameter(cmd, "AddresssLine1", DbType.String, supplier.AddresssLine1);
                db.AddInParameter(cmd, "AddresssLine2", DbType.String, supplier.AddresssLine2);
                db.AddInParameter(cmd, "AddresssLine3", DbType.String, supplier.AddresssLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, supplier.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, supplier.Email);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, supplier.IsActive);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, 1);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                    rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static bool Update(Supplier supplier, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_Update);

                db.AddInParameter(cmd, "SupplierID", DbType.String, supplier.SupplierID);
                db.AddInParameter(cmd, "SupplierName", DbType.String, supplier.SupplierName);
                db.AddInParameter(cmd, "AddresssLine1", DbType.String, supplier.AddresssLine1);
                db.AddInParameter(cmd, "AddresssLine2", DbType.String, supplier.AddresssLine2);
                db.AddInParameter(cmd, "AddresssLine3", DbType.String, supplier.AddresssLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, supplier.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, supplier.Email);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, supplier.IsActive);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, supplier.UpdatedBY);

                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static bool Delete(int supplierID, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_Delete);

                db.AddInParameter(cmd, "SupplierID", DbType.String, supplierID);

                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static Supplier GetByName(string supplierName, string executedBy)
        {
            Supplier supplier = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_Select);

                db.AddInParameter(cmd, "SupplierName", DbType.String, supplierName);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    supplier = Utility.DataTableToCollection<Supplier>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                supplier = null;
            }

            return supplier ;

        }

        public static Supplier GetById(int supplierId, string executedBy)
        {
            Supplier supplier = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Supplier_Select_By_Id);

                db.AddInParameter(cmd, "SupplierId", DbType.Int32, supplierId);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    supplier = Utility.DataTableToCollection<Supplier>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                supplier = null;
            }

            return supplier ;

        }
    }
}
