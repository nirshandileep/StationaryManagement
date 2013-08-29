using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Package
{
    public class Package
    {

        public int PackageID { get; set; }
        public Item.Item Item { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public int QtyPerPack { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
