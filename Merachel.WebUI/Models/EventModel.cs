using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class EventModel
    {
        public IEnumerable<Event> eventlist { get; set; }
        public List<EventPicture> picturelist { get; set; }
        public IEnumerable<EventPrice> pricelist { get; set; }
    }
}