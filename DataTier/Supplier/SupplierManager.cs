using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Supplier
{
    public class SupplierManager
    {
        public static bool AddSupplier(Supplier supplier, string executedBy)
        {
            return SupplierDAO.Insert(supplier, executedBy);
        }

        public static List<Supplier> GetAllSupplier(Supplier srchSupplier, string executedBy)
        {
            return SupplierDAO.GetAll(srchSupplier, executedBy);
        }

        public static bool UpdateSupplier(Supplier supplier, string executedBy)
        {
            return SupplierDAO.Update(supplier, executedBy);
        }

        public static bool DeleteSupplier(int supplierID, string executedBy)
        {
            return SupplierDAO.Delete(supplierID, executedBy);
        }

        public static Supplier GetSupplierByCode(string supplierName, string executedBy)
        {
            return SupplierDAO.GetByName(supplierName, executedBy);
        }

        public static Supplier GetSupplierByID(int supplierId, string executedBy)
        {
            return SupplierDAO.GetById(supplierId, executedBy);
        }
    }
}
