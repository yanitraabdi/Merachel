using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    [Authorize]
    public class AdminBlogController : BaseController
    {
        private ActionResult CustomView(string pageName)
        {
            InitConfiguration();
            config.ModuleName = "Merachel Admin Blog";
            config.MenuName = pageName;
            return View(config);
        }

        public ActionResult Blog()
        {
            return CustomView("Blog");
        }

        public ActionResult BlogCategory()
        {
            return CustomView("Blog Category");
        }
    }
}