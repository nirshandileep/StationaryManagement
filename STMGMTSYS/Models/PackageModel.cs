using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataTier.Item;
using System.Web.Mvc;

namespace STMGMTSYS.Models
{
    public class PackageModel
    {
        [Key]
        public int PackageID { get; set; }

        [Required(ErrorMessage="Item Required")]
        public Item Item { get; set; }
        public string PackageCode { get; set; }

        [Required(ErrorMessage = "Package Name Required")]
        public string PackageName { get; set; }

        [Required(ErrorMessage = "Qty Required")]
        public int QtyPerPack { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<SelectListItem> Items { get; set; }

        public PackageModel()
        {
            List<Item> allItems = ItemManager.GetAllItem(new Item() { ItemCode = "", IsActive = true , Name = "" }, "nirshan");
            Items = allItems.Select(map =>
                new SelectListItem 
                { 
                    Text = map.ItemCode, 
                    Value = map.ItemID.ToString() 
                }).ToList();

        }
    }
}