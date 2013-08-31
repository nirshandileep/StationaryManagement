using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Order
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusID { get; set; }
        public decimal TotalValue { get; set; }
        public bool IsPaid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<OrderDetail> OrderItems { get; set; }
       
    }
}
