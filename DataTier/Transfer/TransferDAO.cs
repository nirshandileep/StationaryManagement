using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CommonTier;
using System.Data.Common;
using System.Data;

namespace DataTier.Transfer
{
    public class TransferDAO
    {
        static DbConnection connection = null;
        static DbTransaction transaction = null;

        #region Transfers

        public static bool Insert(Transfer transfer, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Transfer_Insert);

                connection = db.CreateConnection();
                    connection.Open();
                    transaction = connection.BeginTransaction();
                
                db.AddInParameter(cmd, "TransferDate", DbType.DateTime, transfer.TransferDate);
              db.AddInParameter(cmd, "FromBranch", DbType.Int32, transfer.FromBranch);
                db.AddInParameter(cmd, "ToBranch", DbType.Int32, transfer.ToBranch);
                //db.AddInParameter(cmd, "TransferDate", DbType.DateTime, transfer.IsReceived);
                 db.AddInParameter(cmd, "IsApproved", DbType.Boolean, transfer.IsApproved);
                db.AddInParameter(cmd, "ApprovedBy", DbType.DateTime, transfer.ApprovedBy);
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, transfer.CreatedBy);
  
                db.AddOutParameter(cmd, "NewID", DbType.Int32, 4);

                db.ExecuteNonQuery(cmd, transaction);

                int newID = 0;
                int.TryParse(db.GetParameterValue(cmd, "NewID").ToString(), out newID);

                if (newID > 0)
                {
                    bool dtlInserted;
                    foreach (TransferDetail trDtl in transfer.TransferItems)
                    {
                        dtlInserted = InsertDetail(trDtl, transaction, executedBy);
                        if (dtlInserted == false)
                       {
                           throw new Exception("Failed to insert transfer detail/s");
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
                if(connection.State == ConnectionState.Open)
                {
                    connection.Close();
                 }
            }

            return rslt;

        }

        public static bool Update(Transfer transfer, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Transfer_Update);

                connection = db.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                db.AddInParameter(cmd, "TransferID", DbType.Int32, transfer.TransferID);
                db.AddInParameter(cmd, "TransferDate", DbType.DateTime, transfer.TransferDate);
                db.AddInParameter(cmd, "FromBranch", DbType.Int32, transfer.FromBranch);
                db.AddInParameter(cmd, "ToBranch", DbType.Int32, transfer.ToBranch);
                db.AddInParameter(cmd, "IsReceived", DbType.Boolean, transfer.IsReceived);
                 db.AddInParameter(cmd, "RecievedBy", DbType.Int32, transfer.RecievedBy);
                db.AddInParameter(cmd, "IsApproved", DbType.Boolean, transfer.IsApproved);
                db.AddInParameter(cmd, "ApprovedBy", DbType.Int32, transfer.ApprovedBy);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, transfer.UpdatedBY);
                db.AddInParameter(cmd, "LastUpdatedDate", DbType.Int32, transfer.UpdatedDate);

                db.ExecuteNonQuery(cmd, transaction);

                bool dtlUpdated;
                foreach (TransferDetail trDtl in transfer.TransferItems)
                {
                    dtlUpdated = UpdateDetail(trDtl, transaction, executedBy);
                    if (dtlUpdated == false)
                    {
                        throw new Exception("Failed to update transfer detail/s");
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

        public static Transfer GetByID(int transferID, string executedBy)
        {
            Transfer transfer = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Transfer_GetByID);

                db.AddInParameter(cmd, "TransferID", DbType.Int32, transferID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    transfer = Utility.DataTableToCollection<Transfer>(ds.Tables[0]).FirstOrDefault();

                    if (transfer != null)
                    {
                        transfer.TransferItems = GetAllDetailsByID(transfer.TransferID, executedBy);
                    }
                }

            }

            catch (Exception ex)
            {
                transfer = null;
            }

            return transfer;

        }

        public static List<Transfer> Search(Transfer srchTransfer, string executedBy)
        {
            List<Transfer> transferList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Transfer_Search);

                db.AddInParameter(cmd, "TransferCode", DbType.String, srchTransfer.TransferCode);
                db.AddInParameter(cmd, "TransferDate", DbType.DateTime, srchTransfer.TransferDate);
                db.AddInParameter(cmd, "FromBranch", DbType.Int32, srchTransfer.FromBranch);
                db.AddInParameter(cmd, "ToBranch", DbType.Int32, srchTransfer.ToBranch);
                
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    transferList = Utility.DataTableToCollection<Transfer>(ds.Tables[0]);
                }

            }

            catch (Exception ex)
            {
                transferList = null;
            }

            return transferList;

        }

        public static bool ApproveBulk(string transferIDs, int approvedBy, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_Transfer_ApproveBulk);


                db.AddInParameter(cmd, "TransferIDs", DbType.Int32, transferIDs);
                db.AddInParameter(cmd, "ApprovedBy", DbType.Int32, approvedBy);
              
                db.ExecuteNonQuery(cmd);

                rslt = true;
            }

            catch (Exception ex)
            {
                rslt = false;
                throw ex;
            }
           
            return rslt;

        }

        #endregion

        #region Transfer Details

        protected static bool InsertDetail(TransferDetail transferDetail, DbTransaction pTransaction, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_TransferDetail_Insert);

                db.AddInParameter(cmd, "TransferID", DbType.Int32, transferDetail.TransferID);
                db.AddInParameter(cmd, "ItemID", DbType.Int32, transferDetail.ItemID);
                db.AddInParameter(cmd, "QtyTransferred", DbType.Int32, transferDetail.QtyTransferred);
                
                db.AddInParameter(cmd, "CreatedBy", DbType.Int32, transferDetail.CreatedBy);

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

        protected static bool UpdateDetail(TransferDetail transferDetail, DbTransaction pTransaction, string executedBy)
        {
            bool rslt = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_TransferDetail_Update);

                db.AddInParameter(cmd, "TransferDetailID", DbType.Int32, transferDetail.TransferDetailID);
                db.AddInParameter(cmd, "ItemID", DbType.Int32, transferDetail.ItemID);
                db.AddInParameter(cmd, "QtyTransferred", DbType.Int32, transferDetail.QtyTransferred);
                db.AddInParameter(cmd, "QtyReceived", DbType.Int32, transferDetail.QtyReceived);
                db.AddInParameter(cmd, "UpdatedBY", DbType.Int32, transferDetail.UpdatedBY);
                //db.AddInParameter(cmd, "UpdatedDate", DbType.Int32, transferDetail.UpdatedDate);

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

        public static TransferDetail GetDetailByDetailID(int transferDetailID, string executedBy)
        {
            TransferDetail transferDetail = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_TransferDetail_Select);

                db.AddInParameter(cmd, "TransferDetailID", DbType.Int32, transferDetailID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    transferDetail = Utility.DataTableToCollection<TransferDetail>(ds.Tables[0]).FirstOrDefault();
                }

            }

            catch (Exception ex)
            {
                transferDetail = null;
            }

            return transferDetail;

        }

        protected static List<TransferDetail> GetAllDetailsByID(int transferID, string executedBy)
        {
            List<TransferDetail> transferDetailsList = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase(Constants.DBConnection);
                DbCommand cmd = db.GetStoredProcCommand(Constants.SP_TransferDetail_GetByTransferID);

                db.AddInParameter(cmd, "TransferID", DbType.String, transferID);
                
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    transferDetailsList = Utility.DataTableToCollection<TransferDetail>(ds.Tables[0]);
                }

            }

            catch (Exception ex)
            {
                transferDetailsList = null;
            }

            return transferDetailsList;

        }

        #endregion
    }
}
