using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Shipment
{
    public class ShipmentPackage
    {
        public int ShipmentPackageID { get; set; }
        public int ShipmentID { get; set; }
        public int PackageID { get; set; }
        public int NumberOfPacks { get; set; }
        public decimal UnitRate { get; set; }
        public int TotalNumberOfItems { get; set; }
        public int TotAvailable { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
