using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataTier.Customer;

namespace STMGMTSYS_SERVICE
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class STMGMTService : ISTMGMTService
    {
        public List<ICustomer> GetAllCustomers(string executedBy)
        {
            return CustomerManager.GetAllCustomer(executedBy);
        }

        public bool AddCustomer(ICustomer customer, string executedBy)
        {
            return CustomerManager.AddCustomer(customer, executedBy);
        }
    }
}
