using Merachel.BusinessProcess;
using Merachel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    public class AdminController : BaseController
    {
        private ActionResult CustomView(string pageName)
        {
            InitConfiguration();
            config.ModuleName = "Merachel Admin Blog";
            config.MenuName = pageName;
            return View(config);
        }

        [CustomAuthorize]
        public ActionResult Index()
        {
            return CustomView("Dashboard");
        }

        [Route("~/")]
        [Route("")]
        [AllowAnonymous]
        public ActionResult Login()
        {
            InitConfiguration();

            if (config.SessionInfo != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(config);
        }

        #region LOGIN
        [AcceptVerbs(HttpVerbs.Post)]
        [AllowAnonymous]
        public JsonResult Logon(string username, string password, bool rememberMe)
        {
            AccountModel oResult = new AccountModel();

            try
            {
                if (ModelState.IsValid)
                {
                    using (var svc = new LoginServices())
                    {
                        oResult = svc.GetSignInUser(username, password);

                        if (oResult.Exception.ErrorCode == 0)
                            IdentitySignin(oResult, null, rememberMe);

                    }
                }
            }
            catch (Exception ex)
            {
                oResult.Exception = oException.Set(ex);
            }
            return Json(oResult, JsonRequestBehavior.AllowGet);
        }
    }
}