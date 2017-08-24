using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface ICoursePriceRepository
    {
        IQueryable<CoursePrice> CoursePrices { get; }

        void SaveCoursePrice(CoursePrice price);
        CoursePrice DeleteCoursePrice(int priceid);
    }
}
