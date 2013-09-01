using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.User
{
    public class Role
    {
     
        public int RoleID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
