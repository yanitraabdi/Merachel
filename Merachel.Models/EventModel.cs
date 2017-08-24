using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class EventModel : GeneralModel
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }
        public string EventHost { get; set; }
        public DateTime EventTimeStart { get; set; }
        public DateTime EventTimeEnd { get; set; }
        public DateTime EventDateCreated { get; set; }
        public DateTime EventBeginDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public int Status { get; set; }

        public List<EventPictureModel> ListPicture { get; set; }
        public List<EventPriceModel> ListPrice { get; set; }
    }
}
