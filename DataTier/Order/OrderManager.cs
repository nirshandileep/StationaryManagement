using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier.Order
{
    public class OrderManager
    {
        #region Order

        public static bool AddOrder(Order order, string executedBy)
        {
            return OrderDAO.Insert(order, executedBy);
        }

        public static bool UpdateOrder(Order order, string executedBy)
        {
            return OrderDAO.Update(order, executedBy);
        }

        public static List<Order> SearchOrder(Order order, string executedBy)
        {
            return OrderDAO.Search(order, executedBy);
        }

        public static Order GetOrderByID(int orderID, string executedBy)
        {
            return OrderDAO.GetByID(orderID, executedBy);
        }

      
        #endregion

        #region Order Detail

        public static OrderDetail GetOrderDetailByID(int orderDetailID, string executedBy)
        {
            return OrderDAO.GetDetailByDetailID(orderDetailID, executedBy);
        }

        #endregion
    }
}
