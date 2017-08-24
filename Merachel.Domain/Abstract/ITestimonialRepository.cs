using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface ITestimonialRepository
    {
        IQueryable<Testimonial> Testimonials { get; }

        void SaveTestimonial(Testimonial testimonial);
        void SaveSimpleTestimonial(Testimonial testimonial);
        Testimonial DeleteTestimonial(int testimonialid);
    }
}
