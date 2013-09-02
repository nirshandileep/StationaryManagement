using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Shipment
{
    public class Shipment
    {

        public int ShipmentID { get; set; }
        public DateTime Date { get; set; }
        public int SupplierID { get; set; }
        public decimal TotalValue { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<ShipmentPackage> ShipmentPackages { get; set; }
    }
}
