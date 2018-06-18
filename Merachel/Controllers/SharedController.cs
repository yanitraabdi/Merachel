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

        [HttpPost]
        [Route("UploadTestimonial")]
        public ContentResult UploadTestimonial()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload/Testimonial"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Testimonial"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload/Testimonial"), Path.GetFileName(hpf.FileName));
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

        [HttpPost]
        [Route("UploadTutor")]
        public ContentResult UploadTutor()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload/Tutor"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Tutor"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload/Tutor"), Path.GetFileName(hpf.FileName));
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

        [HttpPost]
        [Route("UploadEvent")]
        public ContentResult UploadEvent()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload/Event"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Event"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload/Event"), Path.GetFileName(hpf.FileName));
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

        [HttpPost]
        [Route("UploadCollection")]
        public ContentResult UploadCollection()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload/Collection"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Collection"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload/Collection"), Path.GetFileName(hpf.FileName));
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

        [HttpPost]
        [Route("UploadCourse")]
        public ContentResult UploadCourse()
        {
            var r = new List<UploadFileModel>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;

                bool exists = Directory.Exists(Server.MapPath("~/Upload/Course"));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Course"));

                string savedFileName = Path.Combine(Server.MapPath("~/Upload/Course"), Path.GetFileName(hpf.FileName));
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