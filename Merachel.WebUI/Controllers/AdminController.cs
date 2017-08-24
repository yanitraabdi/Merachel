using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;
using Merachel.Domain.Concrete;
using Merachel.WebUI.Models;
using Merachel.WebUI.Infrastructure;
using System.Web.Security;

namespace Merachel.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBlogCategoryRepository blogcategoryrepository;
        private IBlogRepository blogrepository;
        private ICollectionRepository collectionrepository;
        private IColletionPictureRepository collectionpicturerepository;
        private ICourseRepository courserepository;
        private ICourseCategoryRepository coursecategoryrepository;
        private ICoursePriceRepository coursepricerepository;
        private IEventRepository eventrepository;
        private IEventPriceRepository eventpricerepository;
        private IEventPictureRepository eventpicturerepository;
        private IUserRepository userrepository;
        private IEmployeeRepository employeerepository;
        private ITestimonialRepository testimonialrepository;
        private ILookupRepository lookuprepository;
        EFDbContext db = new EFDbContext();

        public AdminController (
            IBlogRepository blogrepo,
            IBlogCategoryRepository blogcategoryrepo,
            ICollectionRepository collectionrepo,
            IColletionPictureRepository collectionpicturerepo,
            ICourseRepository courserepo,
            ICourseCategoryRepository coursecategoryrepo,
            ICoursePriceRepository coursepricerepo,
            IEventRepository eventrepo,
            IEventPictureRepository eventpicturerepo,
            IEventPriceRepository eventpricerepo,
            IUserRepository userrepo,
            IEmployeeRepository employeerepo,
            ITestimonialRepository testimonialrepo,
            ILookupRepository lookuprepositoryrepo
            )
        {
            blogrepository = blogrepo;
            blogcategoryrepository = blogcategoryrepo;
            collectionrepository = collectionrepo;
            collectionpicturerepository = collectionpicturerepo;
            courserepository = courserepo;
            coursecategoryrepository = coursecategoryrepo;
            coursepricerepository = coursepricerepo;
            eventrepository = eventrepo;
            eventpricerepository = eventpricerepo;
            eventpicturerepository = eventpicturerepo;
            userrepository = userrepo;
            employeerepository = employeerepo;
            testimonialrepository = testimonialrepo;
            lookuprepository = lookuprepositoryrepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        //------------------------------- BLOG CATEGORY -------------------------------------//

        public ViewResult BlogCategory()
        {
            IEnumerable<BlogCategory> blog = blogcategoryrepository.BlogCategories.Where(p => p.BlogCategoryStatus == true).ToList();
            return View(blog);
        }

        public ActionResult AddBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlogCategory(BlogCategory blog)
        {
            if (ModelState.IsValid)
            {
                blogcategoryrepository.SaveBlogCategory(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogCategoryName);
                return RedirectToAction("BlogCategory");
            }
            return View(blog);
        }

        public ActionResult EditBlogCategory(int blogcategoryid)
        {
            BlogCategory blog = db.BlogCategories.Find(blogcategoryid);

            return View(blog);
        }

        [HttpPost]
        public ActionResult EditBlogCategory(BlogCategory blog)
        {
            if (ModelState.IsValid)
            {
                blogcategoryrepository.SaveBlogCategory(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogCategoryName);
                return RedirectToAction("BlogCategory");
            }
            else
            {
                return View(blog);
            }
        }

        [HttpPost]
        public ActionResult DeleteBlogCategory(int blogcategoryid)
        {
            BlogCategory delete = blogcategoryrepository.DeleteBlogCategory(blogcategoryid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.BlogCategoryName);
            }
            return RedirectToAction("BlogCategory");
        }

        //------------------------------- BLOG -------------------------------------//

        public ViewResult Blog()
        {
            IEnumerable<Blog> blog = blogrepository.Blogs.Where(p => p.BlogStatus == true).ToList();
            return View(blog);
        }

        public ActionResult AddBlog()
        {
            ViewBag.Category = db.BlogCategories;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddBlog(Blog blog, HttpPostedFileBase image)
        {
            ViewBag.Category = db.BlogCategories;

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    blog.BlogPictureMimeType = image.ContentType;
                    blog.BlogPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(blog.BlogPictureImageData, 0, image.ContentLength);
                }
                blogrepository.SaveBlog(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogTitle);
                return RedirectToAction("Blog");
            }
            return View(blog);
        }

        public ActionResult EditBlog(int blogid)
        {
            Blog blog = db.Blogs.Find(blogid);

            ViewBag.Category = db.BlogCategories;

            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlog(Blog blog, HttpPostedFileBase image)
        {
            ViewBag.Category = db.BlogCategories;

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    blog.BlogPictureMimeType = image.ContentType;
                    blog.BlogPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(blog.BlogPictureImageData, 0, image.ContentLength);
                }
                blogrepository.SaveBlog(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogTitle);
                return RedirectToAction("Blog");
            }
            else
            {
                return View(blog);
            }
        }

        [HttpPost]
        public ActionResult DeleteBlog(int blogid)
        {
            Blog delete = blogrepository.DeleteBlog(blogid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.BlogTitle);
            }
            return RedirectToAction("Blog");
        }

        //------------------------------- COURSE CATEGORY -------------------------------------//

        public ViewResult CourseCategory()
        {
            IEnumerable<CourseCategory> category = coursecategoryrepository.CourseCategories.Where(p => p.CourseCategoryStatus == true).ToList();
            return View(category);
        }

        public ActionResult AddCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourseCategory(CourseCategory category)
        {
            if (ModelState.IsValid)
            {
                coursecategoryrepository.SaveCourseCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.CourseCategoryName);
                return RedirectToAction("CourseCategory");
            }
            return View(category);
        }

        public ActionResult EditCourseCategory(int coursecategoryid)
        {
            CourseCategory category = db.CourseCategories.Find(coursecategoryid);

            return View(category);
        }

        [HttpPost]
        public ActionResult EditCourseCategory(CourseCategory category)
        {
            if (ModelState.IsValid)
            {
                coursecategoryrepository.SaveCourseCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.CourseCategoryName);
                return RedirectToAction("CourseCategory");
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult DeleteCourseCategory(int coursecategoryid)
        {
            CourseCategory delete = coursecategoryrepository.DeleteCourseCategory(coursecategoryid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.CourseCategoryName);
            }
            return RedirectToAction("CourseCategory");
        }

        //------------------------------- COURSE -------------------------------------//

        public ViewResult Course()
        {
            IEnumerable<Course> course = courserepository.Courses.Where(p => p.CourseStatus == true).ToList();
            return View(course);
        }

        public ActionResult AddCourse()
        {
            ViewBag.Category = db.CourseCategories;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCourse(Course course, HttpPostedFileBase image)
        {
            ViewBag.Category = db.CourseCategories;

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    course.CoursePictureMimeType = image.ContentType;
                    course.CoursePictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(course.CoursePictureImageData, 0, image.ContentLength);
                }
                courserepository.SaveCourse(course);
                TempData["message"] = string.Format("{0} has been saved", course.CourseName);
                return RedirectToAction("Course");
            }
            return View(course);
        }

        public ActionResult EditCourse(int courseid)
        {
            Course course = db.Courses.Find(courseid);

            ViewBag.Category = db.CourseCategories;

            return View(course);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditCourse(Course course, HttpPostedFileBase image)
        {
            ViewBag.Category = db.CourseCategories;

            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    courserepository.SaveSimpleCourse(course);
                    TempData["message"] = string.Format("{0} has been saved", course.CourseName);
                }
                else
                {
                    course.CoursePictureMimeType = image.ContentType;
                    course.CoursePictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(course.CoursePictureImageData, 0, image.ContentLength);

                    courserepository.SaveCourse(course);
                    TempData["message"] = string.Format("{0} has been saved", course.CourseName);
                }
                return RedirectToAction("Course");
            }
            else
            {
                return View(course);
            }
        }

        [HttpPost]
        public ActionResult DeleteCourse(int courseid)
        {
            Course delete = courserepository.DeleteCourse(courseid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.CourseName);
            }
            return RedirectToAction("Course");
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

        //------------------------------- COURSE PRICE -------------------------------------//

        public ViewResult CoursePrice(int courseid)
        {
            IEnumerable<CoursePrice> price = coursepricerepository.CoursePrices.Where(p => p.CoursePriceStatus == true && p.CourseID == courseid).ToList();
            return View(price);
        }

        public ActionResult AddCoursePrice(int courseid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCoursePrice(CoursePrice price, int courseid)
        {
            if (ModelState.IsValid)
            {
                price.CourseID = courseid;
                coursepricerepository.SaveCoursePrice(price);
                TempData["message"] = string.Format("{0} has been saved", price.CoursePriceName);
                return RedirectToAction("Course");
            }
            return View(price);
        }

        public ActionResult EditCoursePrice(int coursepriceid, int courseid)
        {
            Course course = db.Courses.Find(coursepriceid);

            return View(course);
        }

        [HttpPost]
        public ActionResult EditCoursePrice(CoursePrice price, int courseid)
        {
            if (ModelState.IsValid)
            {
                price.CourseID = courseid;
                coursepricerepository.SaveCoursePrice(price);
                TempData["message"] = string.Format("{0} has been saved", price.CoursePriceName);
                return RedirectToAction("Course");
            }
            else
            {
                return View(price);
            }
        }

        [HttpPost]
        public ActionResult DeleteCoursePrice(int priceid)
        {
            CoursePrice delete = coursepricerepository.DeleteCoursePrice(priceid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.CoursePriceName);
            }
            return RedirectToAction("Course");
        }

        //------------------------------- COLLECTION -------------------------------------//

        public ViewResult Collection()
        {
            IEnumerable<Collection> collection = collectionrepository.Collections.Where(p => p.CollectionStatus == true).ToList();
            return View(collection);
        }

        public ActionResult AddCollection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCollection(Collection collection)
        {
            if (ModelState.IsValid)
            {
                collectionrepository.SaveCollection(collection);
                TempData["message"] = string.Format("{0} has been saved", collection.CollectionTitle);
                return RedirectToAction("Collection");
            }
            return View(collection);
        }

        public ActionResult EditCollection(int collectionid)
        {
            Collection collection = db.Collections.Find(collectionid);

            return View(collection);
        }

        [HttpPost]
        public ActionResult EditCollection(Collection collection)
        {
            if (ModelState.IsValid)
            {
                collectionrepository.SaveCollection(collection);
                TempData["message"] = string.Format("{0} has been saved", collection.CollectionTitle);
                return RedirectToAction("Collection");
            }
            else
            {
                return View(collection);
            }
        }

        [HttpPost]
        public ActionResult DeleteCollection(int collectionid)
        {
            Collection delete = collectionrepository.DeleteCollection(collectionid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.CollectionTitle);
            }
            return RedirectToAction("Collection");
        }

        //------------------------------- COLLECTION PICTURE -------------------------------------//

        public ViewResult CollectionPicture(int collectionid)
        {
            AdminPictureModel picturemodel = new AdminPictureModel
            {
                collectionpicture = db.CollectionPictures.Find(collectionid),
                collectionpicturelist = db.CollectionPictures.Where(p => p.CollectionID == collectionid && p.CollectionPictureStatus == true).ToList()
            };
            return View(picturemodel);
        }

        public PartialViewResult _PartialCollectionPicture(int collectionid)
        {
            return PartialView(collectionid);
        }

        public PartialViewResult _CreateCollectionPicture(int collectionid, CollectionPicture picture, HttpPostedFileBase image)
        {
            collectionid = 1;
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    ModelState.AddModelError("", "Image cannot empty");
                }

                if (image != null)
                {
                    picture.CollectionPictureMimeType = image.ContentType;
                    picture.CollectionPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.CollectionPictureImageData, 0, image.ContentLength);
                }
                picture.CollectionID = collectionid;
                collectionpicturerepository.SaveCollectionPicture(picture);
                TempData["message"] = string.Format("{0} has been saved", picture.CollectionPictureID);
                return PartialView(picture);
            }
            return PartialView(picture);
        }

        [HttpPost]
        public ActionResult DeleteCollectionPicture(int collectionpictureid)
        {
            CollectionPicture deletepicture = collectionpicturerepository.DeleteCollectionPicture(collectionpictureid);

            if (deletepicture != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deletepicture.CollectionPictureID);
            }
            return RedirectToAction("Collection");
        }

        public ActionResult AddCollectionPicture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCollectionPicture(CollectionPicture picture, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    ModelState.AddModelError("", "Image cannot empty");
                }

                if (image != null)
                {
                    picture.CollectionPictureMimeType = image.ContentType;
                    picture.CollectionPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.CollectionPictureImageData, 0, image.ContentLength);
                }
                collectionpicturerepository.SaveCollectionPicture(picture);
                TempData["message"] = string.Format("{0} has been saved", picture.CollectionPictureID);
                return RedirectToAction("Collection");
            }
            return View(picture);
        }

        public FileContentResult GetCollectionImage(int collectionid)
        {
            CollectionPicture pic = collectionpicturerepository.CollectionPictures.FirstOrDefault(p => p.CollectionID == collectionid);
            if (pic != null)
            {
                return File(pic.CollectionPictureImageData, pic.CollectionPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        //------------------------------- EVENT -------------------------------------//

        public ViewResult EventList()
        {
            IEnumerable<Event> events = eventrepository.Events.Where(p => p.EventStatus == true).ToList();
            return View(events);
        }

        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddEvent(Event events)
        {
            if (ModelState.IsValid)
            {
                eventrepository.SaveEvent(events);
                TempData["message"] = string.Format("{0} has been saved", events.EventName);
                return RedirectToAction("EventList");
            }
            return View(events);
        }

        public ActionResult EditEvent(int eventid)
        {
            Event events = db.Events.Find(eventid);

            return View(events);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditEvent(Event events)
        {
            if (ModelState.IsValid)
            {
                eventrepository.SaveEvent(events);
                TempData["message"] = string.Format("{0} has been saved", events.EventName);
                return RedirectToAction("EventList");
            }
            else
            {
                return View(events);
            }
        }

        [HttpPost]
        public ActionResult DeleteEvent(int eventid)
        {
            Event delete = eventrepository.DeleteEvent(eventid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.EventName);
            }
            return RedirectToAction("EventList");
        }

        //------------------------------- EVENT PICTURE -------------------------------------//

        public ViewResult EventPicture(int eventid)
        {
            AdminPictureModel picturemodel = new AdminPictureModel
            {
                eventpicture = db.EventPictures.Find(eventid),
                eventpicturelist = db.EventPictures.Where(p => p.EventID == eventid && p.EventPictureStatus == true).ToList()
            };
            return View(picturemodel);
        }

        public PartialViewResult _PartialEventPicture(int eventid)
        {
            return PartialView(eventid);
        }

        public PartialViewResult _CreateEventPicture(int eventid, EventPicture picture, HttpPostedFileBase image)
        {
            eventid = 1;
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    ModelState.AddModelError("", "Image cannot empty");
                }

                if (image != null)
                {
                    picture.EventPictureMimeType = image.ContentType;
                    picture.EventPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.EventPictureImageData, 0, image.ContentLength);
                }
                picture.EventID = eventid;
                eventpicturerepository.SaveEventPicture(picture);
                TempData["message"] = string.Format("{0} has been saved", picture.EventPictureID);
                return PartialView(picture);
            }
            return PartialView(picture);
        }

        [HttpPost]
        public ActionResult DeleteEventPicture(int eventpictureid)
        {
            EventPicture deletepicture = eventpicturerepository.DeleteEventPicture(eventpictureid);

            if (deletepicture != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deletepicture.EventPictureID);
            }
            return RedirectToAction("EventList");
        }

        public ActionResult AddEventPicture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventPicture(EventPicture picture, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    ModelState.AddModelError("", "Image cannot empty");
                }

                if (image != null)
                {
                    picture.EventPictureMimeType = image.ContentType;
                    picture.EventPictureImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.EventPictureImageData, 0, image.ContentLength);
                }
                eventpicturerepository.SaveEventPicture(picture);
                TempData["message"] = string.Format("{0} has been saved", picture.EventPictureID);
                return RedirectToAction("EventList");
            }
            return View(picture);
        }

        public FileContentResult GetEventPictureImage(int eventid)
        {
            EventPicture pic = eventpicturerepository.EventPictures.FirstOrDefault(p => p.EventID == eventid);
            if (pic != null)
            {
                return File(pic.EventPictureImageData, pic.EventPictureMimeType);
            }
            else
            {
                return null;
            }
        }

        //------------------------------- EVENT PRICE -------------------------------------//

        public ViewResult EventPrice()
        {
            IEnumerable<EventPrice> eventprice = eventpricerepository.EventPrices.Where(p => p.EventPriceStatus == true).ToList();
            return View(eventprice);
        }

        public ActionResult AddEventPrice(int eventid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventPrice(EventPrice eventprice, int eventid)
        {
            if (ModelState.IsValid)
            {
                eventprice.EventID = eventid;
                eventpricerepository.SaveEventPrice(eventprice);
                TempData["message"] = string.Format("{0} has been saved", eventprice.EventPriceName);
                return RedirectToAction("EventPrice");
            }
            return View(eventprice);
        }

        public ActionResult EditEventPrice(int eventpriceid, int eventid)
        {
            EventPrice eventprice = db.EventPrices.Find(eventpriceid);
            return View(eventprice);
        }

        [HttpPost]
        public ActionResult EditEventPrice(EventPrice eventprice, int eventid)
        {
            if (ModelState.IsValid)
            {
                eventprice.EventID = eventid;
                eventpricerepository.SaveEventPrice(eventprice);
                TempData["message"] = string.Format("{0} has been saved", eventprice.EventPriceName);
                return RedirectToAction("EventPrice");
            }
            else
            {
                return View(eventprice);
            }
        }

        [HttpPost]
        public ActionResult DeleteEventPrice(int eventpriceid)
        {
            EventPrice delete = eventpricerepository.DeleteEventPrice(eventpriceid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.EventPriceName);
            }
            return RedirectToAction("Event");
        }

        //------------------------------- USER -------------------------------------//

        public ViewResult User()
        {
            IEnumerable<User> user = userrepository.Users.Where(p => p.UserStatus == true).ToList();
            return View(user);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                userrepository.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.UserFullName);
                return RedirectToAction("User");
            }
            return View(user);
        }

        public ActionResult EditUser(int userid)
        {
            User user = db.Users.Find(userid);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userrepository.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.UserFullName);
                return RedirectToAction("User");
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(int userid)
        {
            User delete = userrepository.DeleteUser(userid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.UserFullName);
            }
            return RedirectToAction("User");
        }

        //------------------------------- EMPLOYEE -------------------------------------//

        public ViewResult Employee()
        {
            IEnumerable<Employee> employee = employeerepository.Employees.Where(p => p.EmployeeStatus == true).ToList();
            return View(employee);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    employee.EmployeeMimeType = image.ContentType;
                    employee.EmployeeImageData = new byte[image.ContentLength];
                    image.InputStream.Read(employee.EmployeeImageData, 0, image.ContentLength);
                }
                employeerepository.SaveEmployee(employee);
                TempData["message"] = string.Format("{0} has been saved", employee.EmployeeName);
                return RedirectToAction("Employee");
            }
            return View(employee);
        }

        public ActionResult EditEmployee(int employeeid)
        {
            Employee employee = db.Employees.Find(employeeid);

            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    employeerepository.SaveSimpleEmployee(employee);
                    TempData["message"] = string.Format("{0} has been saved", employee.EmployeeName);
                }
                else
                {
                    employee.EmployeeMimeType = image.ContentType;
                    employee.EmployeeImageData = new byte[image.ContentLength];
                    image.InputStream.Read(employee.EmployeeImageData, 0, image.ContentLength);

                    employeerepository.SaveEmployee(employee);
                    TempData["message"] = string.Format("{0} has been saved", employee.EmployeeName);
                }
                return RedirectToAction("Employee");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int employeeid)
        {
            Employee delete = employeerepository.DeleteEmployee(employeeid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.EmployeeName);
            }
            return RedirectToAction("Employee");
        }
        
        public FileContentResult GetTutorImage(int employeeid)
        {
            Employee pic = employeerepository.Employees.FirstOrDefault(p => p.EmployeeID == employeeid);
            if (pic != null)
            {
                return File(pic.EmployeeImageData, pic.EmployeeMimeType);
            }
            else
            {
                return null;
            }
        }

        //------------------------------- TESTIMONIAL -------------------------------------//

        public ViewResult Testimonial()
        {
            IEnumerable<Testimonial> testimonial = testimonialrepository.Testimonials.Where(p => p.TestimonialStatus == true).ToList();
            return View(testimonial);
        }

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    testimonial.TestimonialMimeType = image.ContentType;
                    testimonial.TestimonialImageData = new byte[image.ContentLength];
                    image.InputStream.Read(testimonial.TestimonialImageData, 0, image.ContentLength);
                }
                testimonialrepository.SaveTestimonial(testimonial);
                TempData["message"] = string.Format("{0} has been saved", testimonial.TestimonialUser);
                return RedirectToAction("Testimonial");
            }
            return View(testimonial);
        }

        public ActionResult EditTestimonial(int testimonialid)
        {
            Testimonial testimonial = db.Testimonials.Find(testimonialid);

            return View(testimonial);
        }

        [HttpPost]
        public ActionResult EditTestimonial(Testimonial testimonial, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    testimonialrepository.SaveSimpleTestimonial(testimonial);
                    TempData["message"] = string.Format("{0} has been saved", testimonial.TestimonialUser);
                }
                else
                {
                    testimonial.TestimonialMimeType = image.ContentType;
                    testimonial.TestimonialImageData = new byte[image.ContentLength];
                    image.InputStream.Read(testimonial.TestimonialImageData, 0, image.ContentLength);

                    testimonialrepository.SaveTestimonial(testimonial);
                    TempData["message"] = string.Format("{0} has been saved", testimonial.TestimonialUser);
                }
                return RedirectToAction("Testimonial");
            }
            else
            {
                return View(testimonial);
            }
        }

        [HttpPost]
        public ActionResult DeleteTestimonial(int testimonialid)
        {
            Testimonial delete = testimonialrepository.DeleteTestimonial(testimonialid);

            if (delete != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", delete.TestimonialUser);
            }
            return RedirectToAction("Testimonial");
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
    }
}