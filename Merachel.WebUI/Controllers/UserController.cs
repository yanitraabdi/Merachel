using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;
using Merachel.WebUI.Infrastructure;
using Merachel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Merachel.WebUI.Controllers
{
    public class UserController : Controller
    {
        EFDbContext db = new EFDbContext();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.UserEmail, user.UserPassword))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "You are not allowed to login here");
                }
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string email, string password)
        {
            bool IsValid = false;

            using (EFDbContext db = new EFDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserEmail == email);
                if (user != null)
                {
                    if (user.UserPassword == password)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }
    }
}