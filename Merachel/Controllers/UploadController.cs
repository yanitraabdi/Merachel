using Merachel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Merachel.Controllers
{
    [Route("{action=Index}")]
    [RoutePrefix("Upload")]
    public class UploadController : Controller
    {
        [HttpPost]
        [Route("UploadFiles")]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            string serverPath = Server.MapPath("~/Upload");
            foreach (HttpPostedFileBase file in files)
            {
                file.SaveAs(Path.Combine(serverPath, file.FileName));
            }
            return View();
        }
        [HttpPost]
        [Route("UploadTestimonial")]
        public ActionResult UploadTestimonial(IEnumerable<HttpPostedFileBase> files)
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
        public ActionResult UploadTutor(IEnumerable<HttpPostedFileBase> files)
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
        [Route("UploadCollection")]
        public ActionResult UploadCollection(IEnumerable<HttpPostedFileBase> files)
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
        [Route("UploadEvent")]
        public ActionResult UploadEvent(IEnumerable<HttpPostedFileBase> files)
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
        public ActionResult UpdateRemoved(FileJSON filedetail)
        {

            return Json(JsonConvert.SerializeObject(new { Removeditems = filedetail }));
        }
        [HttpGet]
        public JsonResult GetFiles()
        {
            string serverPath = Server.MapPath("~/Upload");
            List<FileDetail> files = dataBaseSimulation();
            //hanya ambil yang flag==1
            return Json(JsonConvert.SerializeObject(new { items = files.Select(x => x).Where(y => y.Flag == 1) }), JsonRequestBehavior.AllowGet);
        }

        private List<FileDetail> dataBaseSimulation()
        {
            return new List<FileDetail>()
            {
                 new FileDetail() { Filename = "DSCF5744.JPG", Flag = 0 },
                 new FileDetail(){ Filename="Screenshot (1).png",Flag=1 },
                 new FileDetail(){ Filename="Screenshot (2).png",Flag=0 },
                 new FileDetail(){ Filename="Screenshot (3).png",Flag=1 },
                 new FileDetail(){ Filename="Screenshot (4).png",Flag=0 }

            };
        }
        public class FileJSON
        {
            public FileJSON()
            {
                Files = new List<FileDetail>();
            }
            public string ProductName { get; set; }
            public List<FileDetail> Files { get; set; }
        }
        public class FileDetail
        {
            public int Flag { get; set; }
            public string Filename { get; set; }
        }
    }
}