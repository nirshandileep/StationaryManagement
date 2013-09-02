using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.User
{
    public class User
    {

        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleDescription { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RemainAttempts { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBY { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
