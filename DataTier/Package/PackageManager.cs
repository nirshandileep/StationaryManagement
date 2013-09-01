using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Package
{
    public class PackageManager
    {
        public static bool AddPackage(Package package, string executedBy)
        {
            return PackageDAO.Insert(package, executedBy);
        }

        public static List<Package> GetAllPackage(Package srchPackage, string executedBy)
        {
            return PackageDAO.GetAll(srchPackage, executedBy);
        }

        public static bool UpdatePackage(Package package, string executedBy)
        {
            return PackageDAO.Update(package, executedBy);
        }

        public static bool DeletePackage(int packageID, string executedBy)
        {
            return PackageDAO.Delete(packageID, executedBy);
        }

        public static Package GetPackageByID(int packageId, string executedBy)
        {
            Package package = PackageDAO.GetById(packageId, executedBy);
            package.Item = Item.ItemDAO.GetByID(package.ItemID, "nirshan");
            return package;
        }
    }
}
