using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CommonTier;
using System.Data;

namespace DataTier.Order
{
    public class OrderDAO
    {
        static DbConnection connection = null;
        static DbTransaction transaction = null;

        #region Orders

        public static bool Insert(Order order, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Order_Insert);

                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                db.AddInParameter(cmd, "CustomerID", DbType.Int32, order.CustomerID);
                db.AddInParameter(cmd, "BranchID", DbType.Int32, order.BranchID);
                db.AddInParameter(cmd, "OrderDate", DbType.DateTime, order.OrderDate);
                db.AddInParameter(cmd, "OrderStatusID", DbType.Int32, order.OrderStatusID);
                db.AddInParameter(cmd, "TotalValue", DbType.Decimal, order.TotalValue);
                db.AddInParameter(cmd, "IsPaid", DbType.Boolean, order.IsPaid);
                db.AddInParameter(cmd, "CreatedBy", DbType.Boolean, order.CreatedBy);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd, transaction);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    bool dtlInserted;
                    foreach (OrderDetail orDtl in order.OrderItems)
                    {
                        dtlInserted = InsertDetail(orDtl, transaction, executedBy);
                        if (dtlInserted == false)
                        {
                            throw new Exception("Failed to insert order detail/s");
                        }
                    }

                    transaction.Commit();
                    rslt = true;
                }
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                rslt = false;
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rslt;

        }

        public static bool Update(Order order, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Order_Update);

                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                db.AddInParameter(cmd, "OrderID", DbType.Int32, order.OrderID);
                db.AddInParameter(cmd, "CustomerID", DbType.Int32, order.CustomerID);
                db.AddInParameter(cmd, "BranchID", DbType.Int32, order.BranchID);
                db.AddInParameter(cmd, "OrderDate", DbType.DateTime, order.OrderDate);
                db.AddInParameter(cmd, "OrderStatusID", DbType.Int32, order.OrderStatusID);
                db.AddInParameter(cmd, "TotalValue", DbType.Decimal, order.TotalValue);
                db.AddInParameter(cmd, "IsPaid", DbType.Boolean, order.IsPaid);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, order.UpdatedBy);
                db.AddInParameter(cmd, "LastUpdatedDate", DbType.Int32, order.UpdatedDate);

                db.ExecuteNonQuery(cmd, transaction);

                bool dtlUpdated;
                foreach (OrderDetail orDtl in order.OrderItems)
                {
                    dtlUpdated = UpdateDetail(orDtl, transaction, executedBy);
                    if (dtlUpdated == false)
                    {
                        throw new Exception("Failed to update order detail/s");
                    }
                }

                transaction.Commit();
                rslt = true;
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                rslt = false;
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rslt;

        }

        public static Order GetByID(int orderID, string executedBy)
        {
            Order order = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Order_GetByID);

                db.AddInParameter(cmd, "OrderID", DbType.Int32, orderID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    order = Utility.DataTableToCollection<Order>(ds.Tables[0]).FirstOrDefault();

                    if (order != null)
                    {
                        order.OrderItems = GetAllDetailsByID(order.OrderID, executedBy);
                    }
                }

            }

            catch (Exception ex)
            {
                order = null;
            }

            return order;

        }

        public static List<Order> Search(Order srchOrder, string executedBy)
        {
            List<Order> orderList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Order_Search);

                db.AddInParameter(cmd, "OrderCode", DbType.String, srchOrder.OrderCode);
                db.AddInParameter(cmd, "CustomerID", DbType.Int32, srchOrder.CustomerID);
                db.AddInParameter(cmd, "BranchID", DbType.Int32, srchOrder.BranchID);
                db.AddInParameter(cmd, "OrderDate", DbType.DateTime, srchOrder.OrderDate);
                db.AddInParameter(cmd, "OrderStatusID", DbType.Int32, srchOrder.OrderStatusID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    orderList = Utility.DataTableToCollection<Order>(ds.Tables[0]);
                }

            }

            catch (Exception ex)
            {
                orderList = null;
            }

            return orderList;

        }

       
        #endregion

        #region Order Details

        protected static bool InsertDetail(OrderDetail orderDetail, DbTransaction pTransaction, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_OrderDetails_Insert);

                db.AddInParameter(cmd, "OrderID", DbType.Int32, orderDetail.OrderID);
                db.AddInParameter(cmd, "ItemID", DbType.Int32, orderDetail.ItemID);
                db.AddInParameter(cmd, "OrderQty", DbType.Int32, orderDetail.OrderQty);

                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, orderDetail.CreatedBy);

                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd, pTransaction);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                    rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
                throw ex;
            }

            return rslt;

        }

        protected static bool UpdateDetail(OrderDetail orderDetail, DbTransaction pTransaction, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_OrderDetails_Update);

                db.AddInParameter(cmd, "OrderDetailID", DbType.Int32, orderDetail.OrderDetailID);
                db.AddInParameter(cmd, "OrderID", DbType.Int32, orderDetail.OrderID);
                db.AddInParameter(cmd, "ItemID", DbType.Int32, orderDetail.ItemID);
                db.AddInParameter(cmd, "OrderQty", DbType.Int32, orderDetail.OrderQty);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, orderDetail.UpdatedBy);
                
                db.ExecuteNonQuery(cmd, pTransaction);
                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
                throw ex;
            }

            return rslt;

        }

        public static OrderDetail GetDetailByDetailID(int orderDetailID, string executedBy)
        {
            OrderDetail orderDetail = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_OrderDetails_Select);

                db.AddInParameter(cmd, "OrderDetailID", DbType.Int32, orderDetailID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    orderDetail = Utility.DataTableToCollection<OrderDetail>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                orderDetail = null;
            }

            return orderDetail;

        }

        protected static List<OrderDetail> GetAllDetailsByID(int orderID, string executedBy)
        {
            List<OrderDetail> orderDetailsList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_OrderDetails_GetByOrderID);

                db.AddInParameter(cmd, "OrderID", DbType.Int32, orderID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    orderDetailsList = Utility.DataTableToCollection<OrderDetail>(ds.Tables[0]);
                }

            }

            catch (Exception ex)
            {
                orderDetailsList = null;
            }

            return orderDetailsList;

        }

        #endregion
    }
}
