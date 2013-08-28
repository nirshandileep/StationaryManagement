using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTier.Customer;
using System.ComponentModel.DataAnnotations;

namespace STMGMTSYS.Models
{
    public class CustomerModel : Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string CustomerCode { get; set; }

        [Required(ErrorMessage= "Name is required")]
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

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