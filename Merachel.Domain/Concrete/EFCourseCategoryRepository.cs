using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFCourseCategoryRepository : ICourseCategoryRepository 
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<CourseCategory> CourseCategories
        {
            get { return context.CourseCategories; }
        }

        public void SaveCourseCategory(CourseCategory category)
        {
            if (category.CourseCategoryID == 0)
            {
                category.CourseCategoryStatus = true;
                category.CourseCategoryDate = DateTime.Now;
                context.CourseCategories.Add(category);
            }
            else
            {
                CourseCategory dbEntry = context.CourseCategories.Find(category.CourseCategoryID);
                if (dbEntry != null)
                {
                    dbEntry.CourseCategoryName = category.CourseCategoryName;
                    dbEntry.CourseCategoryDescription = category.CourseCategoryDescription;
                    dbEntry.CourseCategoryStatus = true;
                }
            }
            context.SaveChanges();
        }

        public CourseCategory DeleteCourseCategory(int categoryid)
        {
            CourseCategory dbEntry = context.CourseCategories.Find(categoryid);
            if (dbEntry != null)
            {
                dbEntry.CourseCategoryStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
