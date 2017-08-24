using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merachel.Domain.Abstract;
using Merachel.WebUI.Models;
using Merachel.Domain.Concrete;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Controllers
{
    public class CollectionController : Controller
    {
        private ICollectionRepository collectionrepository;
        private IColletionPictureRepository picturerepository;
        EFDbContext db = new EFDbContext();

        public CollectionController(
            ICollectionRepository collectionrepo,
            IColletionPictureRepository picturerepo)
        {
            collectionrepository = collectionrepo;
            picturerepository = picturerepo;
        }

        public ActionResult Index()
        {
            CollectionModel model = new CollectionModel()
            {
                collection = collectionrepository.Collections.Where(col => col.CollectionStatus == true).OrderByDescending(col => col.CollectionID).FirstOrDefault(),
                collectionlist = collectionrepository.Collections.Where(list => list.CollectionStatus == true).OrderByDescending(list => list.CollectionID).ToList()
            };
            return View(model);
        }

        public ActionResult Detail(int collectionid)
        {
            CollectionModel model = new CollectionModel()
            {
                collection = db.Collections.Find(collectionid),
                picture = picturerepository.CollectionPictures.Where(p => p.CollectionID == collectionid && p.CollectionPictureStatus == true).ToList()
            };
            return View(model);
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

        public PartialViewResult _PictureList(int collectionid)
        {
            var partialpicture = picturerepository.CollectionPictures.FirstOrDefault(p => p.CollectionID == collectionid);
            return PartialView(partialpicture);
        }
    }
}