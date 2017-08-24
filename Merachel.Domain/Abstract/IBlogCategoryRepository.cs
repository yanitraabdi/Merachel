using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface IBlogCategoryRepository
    {
        IQueryable<BlogCategory> BlogCategories { get; }

        void SaveBlogCategory(BlogCategory blogcategory);
        BlogCategory DeleteBlogCategory(int blogcategoryid);
    }
}
