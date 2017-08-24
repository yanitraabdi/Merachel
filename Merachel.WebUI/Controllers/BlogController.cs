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
    public class BlogController : Controller
    {
        private IBlogCategoryRepository categoryrepository;
        private IBlogRepository blogrepository;

        public BlogController(
            IBlogCategoryRepository categoryrepo,
            IBlogRepository blogrepo)
        {
            categoryrepository = categoryrepo;
            blogrepository = blogrepo;
        }

        public ActionResult Index(int? categoryid)
        {
            if(categoryid == null)
            {
                BlogModel model = new BlogModel
                {
                    categorylist = categoryrepository.BlogCategories.Where(co => co.BlogCategoryStatus == true).ToList(),
                    bloglist = blogrepository.Blogs.Where(co => co.BlogStatus == true).ToList()
                };
                return View(model);
            } else
            {
                BlogModel model = new BlogModel
                {
                    categorylist = categoryrepository.BlogCategories.Where(co => co.BlogCategoryStatus == true).ToList(),
                    bloglist = blogrepository.Blogs.Where(co => co.BlogStatus == true && co.BlogCategoryID == categoryid).ToList()
                };
                return View(model);
            }
        }

        public ActionResult Detail(int blogid)
        {
            Blog blog = blogrepository.Blogs.FirstOrDefault(b => b.BlogID == blogid);
            return View(blog);
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
    }
}