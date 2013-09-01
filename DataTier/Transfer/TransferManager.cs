using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Transfer
{
    public class TransferManager
    {
        #region Transfer

        public static bool AddTransfer(Transfer transfer, string executedBy)
        {
            return TransferDAO.Insert(transfer, executedBy);
        }

        public static bool UpdateTransfer(Transfer transfer, string executedBy)
        {
            return TransferDAO.Update(transfer, executedBy);
        }

        public static List<Transfer> SearchTransfer(Transfer transfer, string executedBy)
        {
            return TransferDAO.Search(transfer, executedBy);
        }

        public static Transfer GetTransferByID(int transferID, string executedBy)
        {
            return TransferDAO.GetByID(transferID, executedBy);
        }

        public static bool ApproveTransferBulk(string transferIDs, int approvedBy, string executedBy)
        {
            return TransferDAO.ApproveBulk(transferIDs, approvedBy, executedBy);
        }

        #endregion

        #region Transfer Detail

        public static TransferDetail GetTransferDetailByID(int transferDetailID, string executedBy)
        {
            return TransferDAO.GetDetailByDetailID(transferDetailID, executedBy);
        }

        #endregion

    }
}
