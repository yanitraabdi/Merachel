using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class HomeModel
    {
        public IEnumerable<CourseCategory> categorylist { get; set; }
        public IEnumerable<Course> courselist { get; set; }
        public IEnumerable<Event> eventlist { get; set; }
        public IEnumerable<Collection> collectionlist { get; set; }
        public Course course { get; set; }
        public IEnumerable<Testimonial> testimoniallist { get; set; }
        public Event events { get; set; }
        public Blog blog { get; set; }
        public Collection collection { get; set; }
        public CollectionPicture picture { get; set; }
    }
}