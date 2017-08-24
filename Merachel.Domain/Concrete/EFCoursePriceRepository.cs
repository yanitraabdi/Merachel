using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFCoursePriceRepository : ICoursePriceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<CoursePrice> CoursePrices
        {
            get { return context.CoursePrices; }
        }

        public void SaveCoursePrice(CoursePrice courseprice)
        {
            if (courseprice.CoursePriceID == 0)
            {
                courseprice.CoursePriceStatus = true;
                courseprice.CoursePriceDate = DateTime.Now;
                context.CoursePrices.Add(courseprice);
            }
            else
            {
                CoursePrice dbEntry = context.CoursePrices.Find(courseprice.CoursePriceID);
                if (dbEntry != null)
                {
                    dbEntry.CoursePriceName = courseprice.CoursePriceName;
                    dbEntry.CoursePriceDescription = courseprice.CoursePriceDescription;
                    dbEntry.CourseID = courseprice.CourseID;
                    dbEntry.CoursePriceTotal = courseprice.CoursePriceTotal;
                    dbEntry.CoursePriceStatus = true;
                }
            }
            context.SaveChanges();
        }

        public CoursePrice DeleteCoursePrice(int coursepriceid)
        {
            CoursePrice dbEntry = context.CoursePrices.Find(coursepriceid);
            if (dbEntry != null)
            {
                dbEntry.CoursePriceStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
