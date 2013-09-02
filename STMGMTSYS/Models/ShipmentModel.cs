using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataTier.Shipment;

namespace STMGMTSYS.Models
{
    public class ShipmentModel
    {
        [Key]
        public int ShipmentID { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Incorrect Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date Required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Supplier Required")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "TotalValue Required")]
        [Display(Name="Total Value")]
        public decimal TotalValue { get; set; }

        [Required(ErrorMessage = "Shipping Note Required")]
        [Display(Name = "Shipping Note")]
        public string Note { get; set; }

        [Editable(false)]
        public int CreatedBy { get; set; }
        [Editable(false)]
        public DateTime CreatedDate { get; set; }
        [Editable(false)]
        public int UpdatedBY { get; set; }
        [Editable(false)]
        public DateTime UpdatedDate { get; set; }

        public List<ShipmentPackage> ShipmentPackages { get; set; }
    }

    public class ShipmentPackageModel 
    {
        [Key]
        public int ShipmentPackageID { get; set; }

        public int ShipmentID { get; set; }
        public int PackageID { get; set; }

        [Required(ErrorMessage = "Number Of Packs required")]
        [Display(Name="Number Of Packs",Description="Number Of Packs")]
        public int NumberOfPacks { get; set; }

        [DataType(DataType.Currency)]
        [Editable(false)]
        public decimal UnitRate { get; set; }

        [Required(ErrorMessage = "Number Of Packs required")]
        [Display(Name = "Number Of Packs", Description = "Number Of Packs")]
        public int TotalNumberOfItems { get; set; }

        [Required(ErrorMessage = "Total Available")]
        [Display(Name = "Total Available", Description = "Total Available")]
        public int TotAvailable { get; set; }

        [Editable(false)]
        public int CreatedBy { get; set; }
        [Editable(false)]
        public DateTime CreatedDate { get; set; }
        [Editable(false)]
        public int UpdatedBY { get; set; }
        [Editable(false)]
        public DateTime UpdatedDate { get; set; }
    }
}