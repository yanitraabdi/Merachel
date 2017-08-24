using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Merachel.Libraries;
using Merachel.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Merachel.Controllers
{
    [Route("{action=Index}")]
    [RoutePrefix("Shared")]
    public class SharedController : BaseController
    {
        // GET: Shared
        public ActionResult Index()
        {
            InitConfiguration();
            return View(config);
        }

        [AllowAnonymous]
        [Route("SetSignOut")]
        public ActionResult SetSignOut(string id)
        {
            try
            {
                Session.RemoveAll();
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Content("", "application/html");
        }

        [HttpPost]
        [Route("UploadFiles")]
        public ContentResult UploadFiles()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName);

                r.Add(new UploadFileModel()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
        }
    }
}