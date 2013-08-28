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
    }
}
