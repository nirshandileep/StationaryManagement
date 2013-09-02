using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTier.User;
using STMGMTSYS.Models;
using DataTier;

namespace STMGMTSYS.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            User user = new User() { UserName = "" };
            List<UserModel> users = Utility.ConvetrToList<UserModel, User>(UserManager.SearchUsers(user, 1));
            ViewBag.RoleID = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
            return View(users);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            UserModel user = Utility.convertSrcToTarget<User, UserModel>(UserManager.GetUserByUserID(id, 1));
            ViewBag.RoleID = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            UserModel user = new UserModel() { IsActive = true, IsLocked = false, RemainAttempts = 10 };
            ViewBag.Roles = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
            return View(user);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            try
            {
                UserManager.AddUser(Utility.convertSrcToTarget<UserModel, User>(user), 1);
                ViewBag.Roles = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            UserModel user = Utility.convertSrcToTarget<User, UserModel>(UserManager.GetUserByUserID(id, 1));
            ViewBag.Roles = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, UserModel user)
        {
            try
            {
                // TODO: Add update logic here
                UserManager.EditUser(Utility.convertSrcToTarget<UserModel, User>(user), 1);
                ViewBag.Roles = Helper_Classes.WebHelper.GetSelectListByEnum<CommonTier.Enum.UserRoles>();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            UserModel user = Utility.convertSrcToTarget<User, UserModel>(UserManager.GetUserByUserID(id, 1));
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                UserManager.Delete(new User() { UserID = id }, 1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
