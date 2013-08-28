using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Branch
{
    public class BranchManager
    {
        public static bool AddBranch(Branch branch, string executedBy)
        {
            return BranchDAO.Insert(branch, executedBy);
        }

        public static List<Branch> GetAllBranch(Branch srchBranch, string executedBy)
        {
            return BranchDAO.GetAll(srchBranch, executedBy);
        }

        public static bool UpdateBranch(Branch branch, string executedBy)
        {
            return BranchDAO.Update(branch, executedBy);
        }

        public static bool DeleteBranch(int branchID, string executedBy)
        {
            return BranchDAO.Delete(branchID, executedBy);
        }

        public static Branch GetBranchById(int id, string executedBy)
        {
            return BranchDAO.GetById(id, executedBy);
        }
    }
}
