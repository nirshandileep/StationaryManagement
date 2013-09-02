using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonTier
{
    public class Constants
    {
        //public static readonly string DBConnection = ConfigurationManager.ConnectionStrings["STMGMT"].ToString();
        public static readonly string DBConnection = "SRM-SYS";

        /// <summary>
        /// Customer
        /// </summary>
        public static readonly string SP_Customer_GetAll = "usp_Customer_GetAll";
        public static readonly string SP_Customer_Insert = "usp_Customer_Insert";
        public static readonly string SP_Customer_Update = "usp_Customer_Update";
        public static readonly string SP_Customer_Delete = "usp_Customer_Delete";
        public static readonly string SP_Customer_Select = "usp_Customer_Select";

        /// <summary>
        /// Supplier
        /// </summary>
        public static readonly string SP_Supplier_GetAll = "usp_Supplier_GetAll";
        public static readonly string SP_Supplier_Insert = "usp_Supplier_Insert";
        public static readonly string SP_Supplier_Update = "usp_Supplier_Update";
        public static readonly string SP_Supplier_Delete = "usp_Supplier_Delete";
        public static readonly string SP_Supplier_Select = "usp_Supplier_Select";
        public static readonly string SP_Supplier_Select_By_Id = "usp_Supplier_Select_ById";


        /// <summary>
        /// Items
        /// </summary>
        public static readonly string SP_Item_GetAll = "usp_Item_GetAll";
        public static readonly string SP_Item_Insert = "usp_Item_Insert";
        public static readonly string SP_Item_Update = "usp_Item_Update";
        public static readonly string SP_Item_Delete = "usp_Item_Delete";
        public static readonly string SP_Item_Select = "usp_Item_Select";
        public static readonly string SP_Item_Select_By_Id = "usp_Item_Select_ById";

        /// <summary>
        /// Branch
        /// </summary>
        public static readonly string SP_Branch_GetAll = "usp_Branch_GetAll";
        public static readonly string SP_Branch_Insert = "usp_Branch_Insert";
        public static readonly string SP_Branch_Update = "usp_Branch_Update";
        public static readonly string SP_Branch_Delete = "usp_Branch_Delete";
        public static readonly string SP_Branch_Select_By_Id = "usp_Branch_Select";

        /// <summary>
        /// Package
        /// </summary>
        public static readonly string SP_Package_GetAll = "usp_Package_GetAll";
        public static readonly string SP_Package_Insert = "usp_Package_Insert";
        public static readonly string SP_Package_Update = "usp_Package_Update";
        public static readonly string SP_Package_Delete = "usp_Package_Delete";
        public static readonly string SP_Package_Select = "usp_Package_Select";


        /// <summary>
        /// Transfer
        /// </summary>
        public static readonly string SP_Transfer_Search = "usp_Transfer_Search";
        public static readonly string SP_Transfer_Insert = "usp_Transfer_Insert";
        public static readonly string SP_Transfer_Update = "usp_Transfer_Update";
        public static readonly string SP_Transfer_GetByID = "usp_Transfer_Select";
        public static readonly string SP_Transfer_ApproveBulk = "usp_Transfer_ApproveBulk";

        /// <summary>
        /// Transfer Details
        /// </summary>
        public static readonly string SP_TransferDetail_Insert = "usp_TransferDetails_Insert";
        public static readonly string SP_TransferDetail_Update = "usp_TransferDetails_Update";
        public static readonly string SP_TransferDetail_Select = "usp_TransferDetails_Select";
        public static readonly string SP_TransferDetail_GetByTransferID = "usp_TransferDetails_GetByTransferID";

        /// <summary>
        /// Order
        /// </summary>
        public static readonly string SP_Order_Insert = "usp_Order_Insert";
        public static readonly string SP_Order_Update = "usp_Order_Update";
        public static readonly string SP_Order_GetByID = "usp_Order_Select";
        public static readonly string SP_Order_Search = "usp_Order_Search";
        

        /// <summary>
        /// Order Details
        /// </summary>
        public static readonly string SP_OrderDetails_Insert = "usp_OrderDetails_Insert";
        public static readonly string SP_OrderDetails_Update = "usp_OrderDetails_Update";
        public static readonly string SP_OrderDetails_Select = "usp_OrderDetails_Select";
        public static readonly string SP_OrderDetails_GetByOrderID = "usp_OrderDetails_GetByOrderID";


        /// <summary>
        /// User
        /// </summary>
        public static readonly string SP_User_GetAll = "usp_User_GetAll";
        public static readonly string SP_User_Insert = "usp_User_Insert";
        public static readonly string SP_User_Update = "usp_User_Update";
        public static readonly string SP_User_Delete = "usp_User_Delete";
        public static readonly string SP_User_Select = "usp_User_Select";
        public static readonly string SP_User_Select_By_Id = "usp_User_Select_ById";

        public static readonly string SP_User_Check_UserName_Exists = "usp_User_Check_UserName_Exist";
        public static readonly string SP_User_Check_Login = "usp_User_Check_Login";
    }
}
