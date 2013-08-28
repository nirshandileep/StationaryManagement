using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Item
{
    public class ItemManager
    {
        public static bool AddItem(Item item, string executedBy)
        {
            return ItemDAO.Insert(item, executedBy);
        }

        public static List<Item> GetAllItem(Item srchItem, string executedBy)
        {
            return ItemDAO.GetAll(srchItem, executedBy);
        }

        public static bool UpdateItem(Item item, string executedBy)
        {
            return ItemDAO.Update(item, executedBy);
        }

        public static bool DeleteItem(int itemID, string executedBy)
        {
            return ItemDAO.Delete(itemID, executedBy);
        }

        public static Item GetItemByID(int itemID, string executedBy)
        {
            return ItemDAO.GetByID(itemID, executedBy);
        }
    }
}
