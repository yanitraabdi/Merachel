using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class CourseModel
    {
        public IEnumerable<CourseCategory> categorylist { get; set; }
        public IEnumerable<Course> courselist { get; set; }
        public Course courses { get; set; }
        public IEnumerable<CoursePrice> pricelist { get; set; }
    }
}