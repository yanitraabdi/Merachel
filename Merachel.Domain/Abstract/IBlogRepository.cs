using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IBlogRepository
    {
        IQueryable<Blog> Blogs { get; }

        void SaveBlog(Blog blog);
        Blog DeleteBlog(int blogid);
    }
}
