using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data;
using CommonTier;

namespace DataTier.Customer
{
    public class CustomerDAO
    {
        public static List<Customer> GetAll(Customer srchCustomer, string executedBy)
        {
            List<Customer> cusList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Customer_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, srchCustomer.IsActive);
                db.AddInParameter(cmd, "Name", DbType.String, srchCustomer.Name);
                db.AddInParameter(cmd, "CustomerCode", DbType.String, srchCustomer.CustomerCode);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    cusList = Utility.DataTableToCollection<Customer>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                cusList = null;
            }

            return cusList;

        }

        public static bool Insert(Customer customer, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Customer_Insert);

                db.AddInParameter(cmd, "Name", DbType.String, customer.Name);
                db.AddInParameter(cmd, "AddressLine1", DbType.String, customer.AddressLine1);
                db.AddInParameter(cmd, "AddressLine2", DbType.String, customer.AddressLine2);
                db.AddInParameter(cmd, "AddressLine3", DbType.String, customer.AddressLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, customer.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, customer.Email);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, customer.IsActive);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, customer.CreatedBy);

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

        public static bool Update(Customer customer, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Customer_Update);

                db.AddInParameter(cmd, "CustomerID", DbType.String, customer.CustomerID);
                db.AddInParameter(cmd, "Name", DbType.String, customer.Name);
                db.AddInParameter(cmd, "AddressLine1", DbType.String, customer.AddressLine1);
                db.AddInParameter(cmd, "AddressLine2", DbType.String, customer.AddressLine2);
                db.AddInParameter(cmd, "AddressLine3", DbType.String, customer.AddressLine3);
                db.AddInParameter(cmd, "Telephone", DbType.String, customer.Telephone);
                db.AddInParameter(cmd, "Email", DbType.String, customer.Email);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, customer.IsActive);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, customer.UpdatedBY);

                db.ExecuteNonQuery(cmd);
                
                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static bool Delete(int customerID, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Customer_Delete);

                db.AddInParameter(cmd, "CustomerID", DbType.String, customerID);
                
                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;

        }

        public static Customer GetByCode(string customerCode, string executedBy)
        {
            Customer customer = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Customer_Select);

                db.AddInParameter(cmd, "CustomerCode", DbType.String, customerCode);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    customer = Utility.DataTableToCollection<Customer>(ds.Tables[0]).FirstOrDefault();
                }
               
            }

            catch (Exception ex)
            {
                customer = null;
            }

            return customer;

        }
    }
}
