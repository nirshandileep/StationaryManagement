using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace STMGMTSYS.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        public string Comments { get; set; }
    }
}