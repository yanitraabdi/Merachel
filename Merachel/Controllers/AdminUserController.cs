using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    public class AdminUserController : BaseController
    {
        private ActionResult CustomView(string pageName)
        {
            InitConfiguration();
            config.ModuleName = "Merachel Admin Blog";
            config.MenuName = pageName;
            return View(config);
        }
        // GET: AdminUser
        public ActionResult Users()
        {
            return CustomView("Users");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}