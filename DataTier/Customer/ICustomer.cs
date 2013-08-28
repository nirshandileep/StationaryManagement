using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Customer
{
    public class Customer
    {
         public int CustomerID { get; set; }
         public string CustomerCode { get; set; }
         public string Name { get; set; }
         public string AddressLine1 { get; set; }
         public string AddressLine2 { get; set; }
         public string AddressLine3 { get; set; }
         public string Telephone { get; set; }
         public string Email { get; set; }
         public bool IsActive { get; set; }
         public int CreatedBy { get; set; }
         public DateTime CreatedDate { get; set; }
         public int UpdatedBY { get; set; }
         public DateTime UpdatedDate { get; set; }
    }
}
