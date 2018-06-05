using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            InitConfiguration();
            return View();
        }

        public ActionResult Detail()
        {
            InitConfiguration();
            return View();
        }
    }
}