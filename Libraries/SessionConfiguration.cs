using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

using System;
using System.Linq;
using System.Web;
using System.Threading;
using System.Security.Claims;
using System.Collections.Generic;
using System.Configuration;

using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

using Merachel.Models;

namespace Merachel.Libraries
{
    public class SessionConfiguration
    {
        private const string SessionKey = "Merachel.Session";
        public AccountModel SessionInfo;
        public SessionConfiguration()
        {
            GetSessionInfo();
        }


        //public AccountModel SessionInfo
        //{
        //    get
        //    {
        //        return Current.Session != null ? Current.Session[SessionKey] as AccountModel : null;
        //    }
        //    set
        //    {
        //        if (value != null)
        //            Current.Session[SessionKey] = value;
        //    }
        //}

        public AccountModel GetSessionInfo()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var claims = identity.Claims.ToList();
            var userStateString = GetClaim(claims, "SessionInfo");

            if (userStateString != null)
            {
                try
                {
                    SessionInfo = JsonConvert.DeserializeObject<AccountModel>(userStateString);
                    SessionInfo.User.UserId = 4;
                    return SessionInfo;
                }
                catch (System.Exception)
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
                    return null;
                }
            }
            return null;
        }
        public static string GetClaim(List<Claim> claims, string key)
        {
            var claim = claims.FirstOrDefault(c => c.Type == key);
            if (claim == null)
                return null;

            return claim.Value;
        }

        private static HttpContextBase Current
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public int GetSessionLoginId()
        {
            AccountModel session = GetSessionInfo();
            return session.User.UserId;
        }
    }
}
