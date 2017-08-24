using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface ICourseCategoryRepository
    {
        IQueryable<CourseCategory> CourseCategories { get; }

        void SaveCourseCategory(CourseCategory coursecategory);
        CourseCategory DeleteCourseCategory(int coursecategoryid);
    }
}
