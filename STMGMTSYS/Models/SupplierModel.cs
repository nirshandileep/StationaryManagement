using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTier.Supplier;
using System.ComponentModel.DataAnnotations;

namespace STMGMTSYS.Models
{
    public class SupplierModel : Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        
        [Required(ErrorMessage="Supplier Name is required")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string AddresssLine1 { get; set; }
        
        public string AddresssLine2 { get; set; }
        public string AddresssLine3 { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Telephone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}