using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using CommonTier;

namespace DataTier.Item
{
    public class ItemDAO
    {
        internal static bool Insert(Item item, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Item_Insert);

                db.AddInParameter(cmd, "ItemCode", DbType.String, item.ItemCode);
                db.AddInParameter(cmd, "Name", DbType.String, item.Name);
                db.AddInParameter(cmd, "CommercialValue", DbType.Currency, item.CommercialValue);
                db.AddInParameter(cmd, "ItemStatusID", DbType.Int32, item.ItemStatusID);
                db.AddInParameter(cmd, "QIH", DbType.Int32, item.QIH);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, item.IsActive);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, 1);
                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    item.ItemID = newID;
                    rslt = true;
                }
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        internal static List<Item> GetAll(Item srchItem, string executedBy)
        {
            List<Item> cusList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Item_GetAll);

                db.AddInParameter(cmd, "IsActive", DbType.Boolean, srchItem.IsActive);
                db.AddInParameter(cmd, "Name", DbType.String, srchItem.Name);
                db.AddInParameter(cmd, "ItemCode", DbType.String, srchItem.ItemCode);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    cusList = Utility.DataTableToCollection<Item>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                cusList = null;
            }

            return cusList;
        }

        internal static bool Update(Item item, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Item_Update);

                db.AddInParameter(cmd, "ItemID", DbType.Int32, item.ItemID);
                db.AddInParameter(cmd, "ItemCode", DbType.String, item.ItemCode);
                db.AddInParameter(cmd, "Name", DbType.String, item.Name);
                db.AddInParameter(cmd, "CommercialValue", DbType.Currency, item.CommercialValue);
                db.AddInParameter(cmd, "ItemStatusID", DbType.Int32, item.ItemStatusID);
                db.AddInParameter(cmd, "QIH", DbType.Int32, item.QIH);
                db.AddInParameter(cmd, "IsActive", DbType.Boolean, item.IsActive);
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

        internal static bool Delete(int itemID, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Item_Delete);

                db.AddInParameter(cmd, "ItemID", DbType.Int32, itemID);
                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
            }

            return rslt;
        }

        internal static Item GetByCode(string itemCode, string executedBy)
        {
            throw new NotImplementedException();
        }

        internal static Item GetByID(int itemID, string executedBy)
        {
            Item item = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Item_Select_By_Id);

                db.AddInParameter(cmd, "ItemID", DbType.Int32, itemID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    item = Utility.DataTableToCollection<Item>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                item = null;
            }

            return item;
        }

    }
}
