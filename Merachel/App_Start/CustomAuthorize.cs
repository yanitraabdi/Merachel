using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;

using Merachel.Models;
using Merachel.Libraries;

namespace Merachel
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IFilter
    {
        AccountModel context = new AccountModel(); // my entity  
        private readonly string[] allowedroles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = true;

            SessionConfiguration oConfig = new SessionConfiguration();
            AccountModel oSession = oConfig.GetSessionInfo();

            RoleInfoModel oRole = (from obj in oSession.UserRoles where obj.Sequence == 1 select obj).FirstOrDefault();

            foreach (var role in allowedroles)
            {
                if (oRole.RoleName.Equals(role, StringComparison.OrdinalIgnoreCase))
                {
                    authorize = true;
                    break;
                }
                else
                {
                    authorize = false;
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new HttpUnauthorizedResult();

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //if not logged, it will work as normal Authorize and redirect to the Login
                //base.HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "action", "Login" },
                    { "controller", "Admin" }
                });
            }
            else
            {
                //logged and wihout the role to access it - redirect to the custom controller action
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "_401" }));
            }
        }

        protected virtual bool IsAuthorized(HttpActionContext actionContext)
        {
            bool authorize = false;

            foreach (var role in allowedroles)
            {
                var user = context.UserRoles.Where(m => m.RoleName == role); // checking active users with allowed roles.  
                if (user.Count() > 0)
                {
                    authorize = true; /* return true if Entity has current user(active) with specific role */
                }
            }
            return authorize;
        }
    }

    public class CustomAuthorizeAPIAttribute : AuthorizationFilterAttribute
    {
        AccountModel context = new AccountModel(); // my entity  
        private readonly string[] allowedroles;

        public CustomAuthorizeAPIAttribute(params string[] roles)
        {
            allowedroles = roles;
        }

        public override bool AllowMultiple
        {
            get { return false; }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool authorize = false;

            SessionConfiguration oConfig = new SessionConfiguration();
            AccountModel oSession = oConfig.GetSessionInfo();

            RoleInfoModel oRole = (from obj in oSession.UserRoles where obj.Sequence == 1 select obj).FirstOrDefault();

            foreach (var role in allowedroles)
            {
                if (oRole.RoleName.Equals(role, StringComparison.OrdinalIgnoreCase))
                {
                    authorize = true;
                    break;
                }
                else
                {
                    authorize = false;
                }
            }

            if (!authorize)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    Content = new StringContent("You are unauthorized to access this page.")
                };
            }
        }
    }
}