using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Supplier
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string AddresssLine1 { get; set; }
        public string AddresssLine2 { get; set; }
        public string AddresssLine3 { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
