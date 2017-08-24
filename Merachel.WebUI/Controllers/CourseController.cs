using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;
using Merachel.WebUI.Models;

namespace Merachel.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseCategoryRepository coursecategoryrepository;
        private ICourseRepository courserepository;
        private ICoursePriceRepository coursepricerepository;
        EFDbContext db = new EFDbContext();

        public CourseController(
            ICourseCategoryRepository coursecategoryrepo,
            ICoursePriceRepository coursepricerepo,
            ICourseRepository courserepo)
        {
            coursecategoryrepository = coursecategoryrepo;
            coursepricerepository = coursepricerepo;
            courserepository = courserepo;
        }

        public ActionResult Index()
        {
            CourseModel model = new CourseModel
            {
                categorylist = coursecategoryrepository.CourseCategories.Where(co => co.CourseCategoryStatus == true).ToList(),
                courselist = courserepository.Courses.Where(co => co.CourseStatus == true).ToList(),
                pricelist = coursepricerepository.CoursePrices.Where(co => co.CoursePriceStatus == true).ToList()
            };
            return View(model);
        }

        public FileContentResult GetCourseImage(int courseid)
        {
            Course pic = courserepository.Courses.FirstOrDefault(p => p.CourseID == courseid);
            if (pic != null)
            {
                return File(pic.CoursePictureImageData, pic.CoursePictureMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}