using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Customer
{
    public class CustomerManager
    {
        public static bool AddCustomer(Customer customer, string executedBy)
        {
            return CustomerDAO.Insert(customer, executedBy);
        }

        public static List<Customer> GetAllCustomer(Customer srchCustomer, string executedBy)
        {
            return CustomerDAO.GetAll(srchCustomer, executedBy);
        }

        public static bool UpdateCustomer(Customer customer, string executedBy)
        {
            return CustomerDAO.Update(customer, executedBy);
        }

        public static bool DeleteCustomer(int customerID, string executedBy)
        {
            return CustomerDAO.Delete(customerID, executedBy);
        }

        public static Customer GetCustomerByCode(string customerCode, string executedBy)
        {
            return CustomerDAO.GetByCode(customerCode, executedBy);
        }
    }
}
