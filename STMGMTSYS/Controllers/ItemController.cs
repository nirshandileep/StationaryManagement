using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STMGMTSYS.Models;
using DataTier.Item;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/

        public ActionResult Index()
        {
            Item srchItem = new Item() { ItemCode = "", Name = "" };
            List<Item> items = ItemManager.GetAllItem(srchItem, "nirshan");
            List<ItemModel> itemModels = Utility.ConvetrToList<ItemModel, Item>(items);
            return View(itemModels);
        }

        
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string name = collection.GetValue("Name").AttemptedValue;
            string code = collection.GetValue("ItemCode").AttemptedValue;
            bool bIsActive = Request.Form.GetValues("active") != null && Request.Form.GetValues("active")[0] != null ? true : false;

            Item srchItem = new Item() { ItemCode = code, Name = name, IsActive = bIsActive };
            List<Item> items = ItemManager.GetAllItem(srchItem, "nirshan");
            List<ItemModel> itemModels = Utility.ConvetrToList<ItemModel, Item>(items);
            return View(itemModels);
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id)
        {
            Item item = ItemManager.GetItemByID(id, "nirshan");
            ItemModel itemModel = Utility.convertSrcToTarget<Item, ItemModel>(item);
            return View(itemModel);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            ViewBag.ItemStatusID = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.Status>();
            return View();
        }

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(ItemModel itemCreate)
        {
            try
            {
                Item newItem = Utility.convertSrcToTarget<ItemModel, Item>(itemCreate);
                ItemManager.AddItem(newItem, "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item/Edit/5

        public ActionResult Edit(int id)
        {
            Item editItem = new Item();
            editItem = ItemManager.GetItemByID(id, "nirshan");
            ItemModel itemModel = Utility.convertSrcToTarget<Item, ItemModel>(editItem);
            return View(itemModel);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ItemModel editItem)
        {
            try
            {
                ItemManager.UpdateItem(Utility.convertSrcToTarget<ItemModel, Item>(editItem), "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item/Delete/5

        public ActionResult Delete(int id)
        {
            ItemManager.DeleteItem(id, "nirshan");
            return RedirectToAction("Index");
        }

        //
        // POST: /Item/Delete/5

        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                int? DelId = (int?)TempData["DelId"];
                ItemManager.DeleteItem(DelId.HasValue ? DelId.Value : 0, "nirshan");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
