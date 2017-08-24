using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.WebUI.Models;
using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Merachel.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICourseCategoryRepository coursecategoryrepository;
        private ICourseRepository courserepository;
        private IBlogRepository blogrepository;
        private ICollectionRepository collectionrepository;
        private IColletionPictureRepository picturerepository;
        private IEventRepository eventrepository;
        private IEventPictureRepository eventpicturerepository;
        private ITestimonialRepository testimonialrepository;
        EFDbContext db = new EFDbContext();

        public HomeController(
            ICourseCategoryRepository coursecategoryrepo,
            ICourseRepository courserepo,
            IBlogRepository blogrepo,
            ICollectionRepository collectionrepo,
            IColletionPictureRepository picturerepo,
            IEventRepository eventrepo,
            IEventPictureRepository eventpicturerepo,
            ITestimonialRepository testimonialrepo)
        {
            coursecategoryrepository = coursecategoryrepo;
            courserepository = courserepo;
            blogrepository = blogrepo;
            collectionrepository = collectionrepo;
            picturerepository = picturerepo;
            eventrepository = eventrepo;
            eventpicturerepository = eventpicturerepo;
            testimonialrepository = testimonialrepo;
        }

        public ActionResult Index()
        {
            HomeModel model = new HomeModel()
            {
                events = eventrepository.Events.Where(e => e.EventStatus == true).OrderBy(e => e.EventID).FirstOrDefault(),
                eventlist = eventrepository.Events.Where(e => e.EventStatus == true).OrderBy(e => e.EventID).ToList(),
                categorylist = coursecategoryrepository.CourseCategories.Where(c => c.CourseCategoryStatus == true).ToList(),
                courselist = courserepository.Courses.Where(c => c.CourseStatus == true).ToList(),
                collectionlist = collectionrepository.Collections.Where(c => c.CollectionStatus == true).OrderByDescending(c => c.CollectionID).ToList().Take(3),
                testimoniallist = testimonialrepository.Testimonials.Where(t => t.TestimonialStatus == true).ToList(),
                blog = blogrepository.Blogs.Where(b => b.BlogStatus == true).OrderByDescending(b => b.BlogID).FirstOrDefault(),
                collection = collectionrepository.Collections.Where(c => c.CollectionStatus == true).OrderByDescending(c => c.CollectionID).FirstOrDefault(),
                course = courserepository.Courses.Where(c => c.CourseStatus == true).FirstOrDefault()
            };
            return View(model);
        }

        public FileContentResult GetEventImage(int eventid)
        {
            EventPicture pic = eventpicturerepository.EventPictures.Where(e => e.EventPictureStatus == true).FirstOrDefault(p => p.EventID == eventid);
            if (pic != null)
            {
                return File(pic.EventPictureImageData, pic.EventPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetCourseImage(int courseid)
        {
            Course pic = courserepository.Courses.Where(e => e.CourseStatus == true).FirstOrDefault(p => p.CourseID == courseid);
            if (pic != null)
            {
                return File(pic.CoursePictureImageData, pic.CoursePictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetTestimonialImage(int testimonialid)
        {
            Testimonial pic = testimonialrepository.Testimonials.FirstOrDefault(p => p.TestimonialID == testimonialid);
            if (pic != null)
            {
                return File(pic.TestimonialImageData, pic.TestimonialMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetCollectionImage(int collectionid)
        {
            CollectionPicture pic = picturerepository.CollectionPictures.FirstOrDefault(p => p.CollectionID == collectionid);
            if (pic != null)
            {
                return File(pic.CollectionPictureImageData, pic.CollectionPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetCollectionImage2(int collectionid)
        {
            CollectionPicture pic = picturerepository.CollectionPictures.FirstOrDefault(p => p.CollectionID == collectionid - 1);
            if (pic != null)
            {
                return File(pic.CollectionPictureImageData, pic.CollectionPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetBlogImage(int blogid)
        {
            Blog pic = blogrepository.Blogs.FirstOrDefault(p => p.BlogID == blogid);
            if (pic != null)
            {
                return File(pic.BlogPictureImageData, pic.BlogPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("merachelfashion@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("website@merachel.com");  // replace with valid value
                message.Subject = string.Format(model.Subject); ;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
    }
}