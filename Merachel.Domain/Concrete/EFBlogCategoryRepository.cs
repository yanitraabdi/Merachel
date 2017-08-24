using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFBlogCategoryRepository : IBlogCategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<BlogCategory> BlogCategories
        {
            get { return context.BlogCategories; }
        }

        public void SaveBlogCategory(BlogCategory blogcategory)
        {
            if (blogcategory.BlogCategoryID == 0)
            {
                blogcategory.BlogCategoryStatus = true;
                blogcategory.BlogCategoryDate = DateTime.Now;
                context.BlogCategories.Add(blogcategory);
            }
            else
            {
                BlogCategory dbEntry = context.BlogCategories.Find(blogcategory.BlogCategoryID);
                if (dbEntry != null)
                {
                    dbEntry.BlogCategoryName = blogcategory.BlogCategoryName;
                    dbEntry.BlogCategoryStatus = true;
                }
            }
            context.SaveChanges();
        }

        public BlogCategory DeleteBlogCategory(int blogcategoryid)
        {
            BlogCategory dbEntry = context.BlogCategories.Find(blogcategoryid);
            if (dbEntry != null)
            {
                dbEntry.BlogCategoryStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
