using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Transfer
{
    public class Transfer
    {
        public int TransferID { get; set; }
        public string TransferCode { get; set; }
        public DateTime TransferDate { get; set; }
        public int FromBranch { get; set; }
        public int ToBranch { get; set; }
        public bool IsReceived { get; set; }
        public int RecievedBy { get; set; }
        public bool IsApproved { get; set; }
        public int ApprovedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<TransferDetail> TransferItems { get; set; }
    }
}
