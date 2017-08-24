using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFBlogRepository : IBlogRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Blog> Blogs
        {
            get { return context.Blogs; }
        }

        public void SaveBlog(Blog blog)
        {
            if (blog.BlogID == 0)
            {
                blog.BlogStatus = true;
                blog.BlogDate = DateTime.Now;
                context.Blogs.Add(blog);
            }
            else
            {
                Blog dbEntry = context.Blogs.Find(blog.BlogID);
                if (dbEntry != null)
                {
                    dbEntry.BlogTitle = blog.BlogTitle;
                    dbEntry.BlogContent = blog.BlogContent;
                    dbEntry.BlogCategoryID = blog.BlogCategoryID;
                    dbEntry.BlogStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Blog DeleteBlog(int blogid)
        {
            Blog dbEntry = context.Blogs.Find(blogid);
            if (dbEntry != null)
            {
                dbEntry.BlogStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
