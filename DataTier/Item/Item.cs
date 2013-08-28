using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Item
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public decimal CommercialValue { get; set; }
        public CommonTier.Enum.Status ItemStatusID { get; set; }
        public int QIH { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
    
    }
}
