using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace STMGMTSYS.Models
{
    public class BranchModel
    {
        [Key]
        public int BranchID { get; set; }
        
        [Required(ErrorMessage="Name Required")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Telephone Required")]
        [DataType(DataType.PhoneNumber, ErrorMessage=" Incorrect format")]
        public string Telephone { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage="Email required")]
        public string Email { get; set; }
        public int MainBranchID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}