using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFTestimonialRepository : ITestimonialRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Testimonial> Testimonials
        {
            get { return context.Testimonials; }
        }

        public void SaveTestimonial(Testimonial testimonial)
        {
            if (testimonial.TestimonialID == 0)
            {
                testimonial.TestimonialStatus = true;
                testimonial.TestimonialDate = DateTime.Now;
                context.Testimonials.Add(testimonial);
            }
            else
            {
                Testimonial dbEntry = context.Testimonials.Find(testimonial.TestimonialID);
                if (dbEntry != null)
                {
                    dbEntry.TestimonialUser = testimonial.TestimonialUser;
                    dbEntry.TestimonialContent = testimonial.TestimonialContent;
                    dbEntry.TestimonialImageData = testimonial.TestimonialImageData;
                    dbEntry.TestimonialMimeType = testimonial.TestimonialMimeType;
                    dbEntry.TestimonialStatus = true;
                }
            }
            context.SaveChanges();
        }

        public void SaveSimpleTestimonial(Testimonial testimonial)
        {
            if (testimonial.TestimonialID == 0)
            {
                testimonial.TestimonialStatus = true;
                testimonial.TestimonialDate = DateTime.Now;
                context.Testimonials.Add(testimonial);
            }
            else
            {
                Testimonial dbEntry = context.Testimonials.Find(testimonial.TestimonialID);
                if (dbEntry != null)
                {
                    dbEntry.TestimonialUser = testimonial.TestimonialUser;
                    dbEntry.TestimonialContent = testimonial.TestimonialContent;
                    dbEntry.TestimonialStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Testimonial DeleteTestimonial(int testimonialid)
        {
            Testimonial dbEntry = context.Testimonials.Find(testimonialid);
            if (dbEntry != null)
            {
                dbEntry.TestimonialStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
