using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merachel.Domain.Entities;

namespace Merachel.WebUI.Models
{
    public class BlogModel
    {
        public IEnumerable<BlogCategory> categorylist { get; set; }
        public IEnumerable<Blog> bloglist { get; set; }
    }
}