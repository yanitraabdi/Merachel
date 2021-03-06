﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merachel.Models
{
    public class TestimonialModel : GeneralModel
    {
        public int TestimonialID { get; set; }
        public string TestimonialUser { get; set; }
        public string TestimonialContent { get; set; }
        public string TestimonialImageName { get; set; }
        public string TestimonialImagePath { get; set; }
        public int? Status { get; set; }
    }
}
