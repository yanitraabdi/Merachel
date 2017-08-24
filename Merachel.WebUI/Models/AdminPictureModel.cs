using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class AdminPictureModel
    {
        public CollectionPicture collectionpicture { get; set; }
        public List<CollectionPicture> collectionpicturelist { get; set; }
        public EventPicture eventpicture { get; set; }
        public List<EventPicture> eventpicturelist { get; set; }
    }
}