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
    public class EventController : Controller
    {
        private IEventRepository eventrepository;
        private IEventPictureRepository picturerepository;
        private IEventPriceRepository pricerepository;

        public EventController(
            IEventRepository eventrepo,
            IEventPictureRepository picturerepo,
            IEventPriceRepository pricerepo)
        {
            eventrepository = eventrepo;
            picturerepository = picturerepo;
            pricerepository = pricerepo;
        }

        public ActionResult Index()
        {
            EventModel model = new EventModel()
            {
                eventlist = eventrepository.Events.Where(e => e.EventStatus == true).ToList(),
                picturelist = picturerepository.EventPictures.Where(p => p.EventPictureStatus == true).ToList(),
                pricelist = pricerepository.EventPrices.Where(p => p.EventPriceStatus == true).ToList()
            };
            return View(model);
        }

        public PartialViewResult _PictureList(int eventid)
        {
            var partialpicture = eventrepository.Events.FirstOrDefault(p => p.EventID == eventid);
            return PartialView(partialpicture);
        }
    }
}