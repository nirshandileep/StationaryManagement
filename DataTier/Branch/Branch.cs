using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Branch
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int MainBranchID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
