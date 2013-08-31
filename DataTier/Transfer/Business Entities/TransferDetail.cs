using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Transfer
{
    public class TransferDetail
    {
        public int TransferDetailID { get; set; }
        public int TransferID { get; set; }
        public int ItemID { get; set; }
        public int QtyTransferred { get; set; }
        public int QtyReceived { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
