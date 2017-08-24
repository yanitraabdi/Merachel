using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading;
using System.Security.Principal;

using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

using Newtonsoft.Json;
using Merachel.Libraries;
using Merachel.Models;

namespace Merachel.Controllers
{
    public class BaseController : Controller
    {
        public Configurations config;
        public ExceptionManagement oException;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public void InitConfiguration()
        {
            config = new Configurations();
            ViewBag.Configuration = Common.GetConfigurationAsJson(config);
        }

        public IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public string[] GetCipherData(string cipher)
        {
            CryptographyConfiguration _crypto = new CryptographyConfiguration();
            var keybytes = Encoding.UTF8.GetBytes(CryptographyConfiguration.AESKey);
            var iv = Encoding.UTF8.GetBytes(CryptographyConfiguration.AESIV);

            var encrypted = Convert.FromBase64String(cipher);
            var decriptedFromJavascript = _crypto.DecryptStringFromBytes(encrypted, keybytes, iv);
            string[] data = decriptedFromJavascript.Split(new string[] { "!@#" }, StringSplitOptions.None);

            return data;
        }

        public void IdentitySignin(AccountModel account, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>();
            List<string> oRoles = new List<string>();

            // create required claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, account.User.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, account.User.UserFullName));
            claims.Add(new Claim("SessionInfo", JsonConvert.SerializeObject(account)));

            foreach (var item in account.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                oRoles.Add(item.RoleName);
            }
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            var claimPrincipal = new GenericPrincipal(identity, oRoles.ToArray());
            Thread.CurrentPrincipal = claimPrincipal;

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7),
            }, identity);

            HttpContext.User = claimPrincipal; //AuthenticationManager.AuthenticationResponseGrant.Principal;
        }

        public void IdentitySignOut()
        {
            Session.RemoveAll();
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
        }

        private string MenuActive(string pageRoute)
        {
            int len = Request.Url.Segments.Length;
            string route = Request.Url.Segments[len - 1];

            if (route.ToLower().Equals(pageRoute.ToLower()))
                return "active";
            else
                return string.Empty;
        }
        private string MenuActive(params string[] pageRoute)
        {
            int len = Request.Url.Segments.Length;
            string route = Request.Url.Segments[len - 1];

            if (pageRoute.Contains<string>(route))
                return "active";
            else
                return string.Empty;
        }

        private string GetAction(string controller, string razor = "Index")
        {
            return Url.Action(razor, controller);
        }
    }
}