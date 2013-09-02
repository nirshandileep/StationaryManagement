using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CommonTier
{
    public class Enum
    {
        public enum Status
        {
            Active = 1,
            [Description("Not Active")]
            Inactive = 2,
        }

        /// <summary>
        /// Keep this synced with the tblUserRoles table in the database
        /// </summary>
        public enum UserRoles
        {
            SuperAdmin = 1,
            Administrator = 2,
            User = 3,
        }
    }
}
