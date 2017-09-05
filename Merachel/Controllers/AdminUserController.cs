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
    }
}