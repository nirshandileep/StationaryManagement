using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CommonTier;

namespace STMGMTSYS.Models
{
    public class ItemModel
    {
        [Key]
        public int ItemID { get; set; }

        [Required(AllowEmptyStrings=false,ErrorMessage="Code Required")]
        [Display(Name="Item Code")]
        public string ItemCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Commercial Value Required")]
        public decimal CommercialValue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Item Status Required")]
        [Display(Name = "Status")]
        public CommonTier.Enum.Status ItemStatusID { get; set; }

        [Required(ErrorMessage="QIH Required")]
        [Display(Name = "Qty In Hand")]
        public int QIH { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}