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
    public class Configurations : SessionConfiguration
    {

        //private const string RegisterEmail = "ODS.Email";
        //private const string QueryStringKey = "ODS.QueryString";

        public Configurations()
        {
            Exception = new ExceptionModel();

            PageTitle = "Merachel";
            HasHeader = true;
            HasFooter = true;
            HasMenuBar = true;
            IsDashBoard = false;
            ModuleName = "New Form";
            MenuName = "New Form";

            // Get current logon user without domain.
            string userName = string.Empty;

            if (HttpContext.Current.User.Identity.Name.IndexOf('@') > 0)
            {
                userName = HttpContext.Current.User.Identity.Name.Split('@')[0];
            }
            else
            {
                if (HttpContext.Current.User.Identity.Name.IndexOf('\\') > 0)
                {
                    userName = HttpContext.Current.User.Identity.Name.Split('\\')[1];
                }
            }

            SessionUserName = userName;

            // Get all default settings.
            this.MerachelUrl = GetServiceUrl(); //GetScheme() + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
            this.MerachelWebUrl = GetWebUrl();

            JavaScriptAndCssVersion = ConfigurationManager.AppSettings["JavaScriptAndCssVersion"];
            string cookieVersion = ConfigurationManager.AppSettings["CookieVersion"];

            // Get configuration settings.
            CookieNameConfiguration = "merachel-configuration-" + cookieVersion;
            CookieValue = "{}";

            AccountModel session = GetSessionInfo();
            if (session != null)
            {
                RoleInfoModel role = (from obj in session.UserRoles where obj.Sequence == 1 select obj).FirstOrDefault();
                RoleName = role.RoleName;
            }
        }

        private string GetScheme()
        {
            return (Convert.ToBoolean(ConfigurationManager.AppSettings["IsSecureConnection"]) ? "https://" : "http://");
        }
        private string GetDomainName()
        {
            return Convert.ToString(ConfigurationManager.AppSettings["MerachelDomainName"]) + "/";
        }
        public string GetWebUrl()
        {
            return Convert.ToString(ConfigurationManager.AppSettings["MerachelWebUrl"]);
        }

        public string GetServiceUrl()
        {
            //bool isHasSubsites = Convert.ToBoolean(ConfigurationManager.AppSettings["IsHasSubsites"]);
            //if (isHasSubsites)
            //    return GetScheme() + HttpContext.Current.Request.Url.Authority + "/" + Convert.ToString(ConfigurationManager.AppSettings["ODSSubsitesServices"]);
            //else
            //    return ODSUrl + "/services";
            return Convert.ToString(ConfigurationManager.AppSettings["MerachelServicesUrl"]);
        }

        public string MerachelUrl { get; }
        public string MerachelWebUrl { get; }
        public string SessionUserName { get; }
        public string CookieNameConfiguration { get; }
        public string CookieValue { get; set; }



        [JsonIgnore]
        public ExceptionModel Exception { get; set; }
        [JsonIgnore]
        public string JavaScriptAndCssVersion { get; }
        [JsonIgnore]
        public string PageTitle { get; set; }
        [JsonIgnore]
        public bool HasHeader { get; set; }
        [JsonIgnore]
        public bool HasMenuBar { get; set; }
        [JsonIgnore]
        public bool HasFooter { get; set; }
        [JsonIgnore]
        public bool IsDashBoard { get; set; }
        [JsonIgnore]
        public string ModuleName { get; set; }
        [JsonIgnore]
        public string MenuName { get; set; }
        [JsonIgnore]
        public string RoleName { get; set; }
    }
}
