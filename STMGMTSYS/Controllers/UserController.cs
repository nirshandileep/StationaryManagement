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
            User user = new User();
            List<UserModel> users = Utility.ConvetrToList<UserModel, User>(UserManager.SearchUsers(user, 1));
            ///
            /// Fill roles drop down
            ///
            return View(users);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            UserModel user = Utility.convertSrcToTarget<User, UserModel>(UserManager.GetUserByUserID(id, 1));
            ///
            /// Fill drop down
            ///
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            UserModel user = new UserModel() { IsActive = true, IsLocked = false, RemainAttempts = 10 };
            ///
            /// Fill drop down
            ///
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
                ///
                /// Fill drop down
                ///
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

            ///
            /// Fill drop down
            ///

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
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
