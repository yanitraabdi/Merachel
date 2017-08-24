using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class CollectionModel
    {
        public Collection collection { get; set; }
        public IEnumerable<Collection> collectionlist { get; set; }
        public List<CollectionPicture> picture { get; set; }
    }
}