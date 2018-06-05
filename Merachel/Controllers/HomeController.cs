﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private ActionResult CustomView(string pageName)
        {
            InitConfiguration();
            config.ModuleName = "Merachel Admin Blog";
            config.MenuName = pageName;
            return View(config);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return CustomView("Home Page");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Gallery()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Event()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Course()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult EventDetail()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult CourseDetail()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Why()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Tutor()
        {
            ViewBag.Message = "Your contact page.";

            InitConfiguration();
            return View();
        }
    }
}