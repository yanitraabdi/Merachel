using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Abstract
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }

        void SaveCourse(Course course);
        void SaveSimpleCourse(Course course);
        Course DeleteCourse(int courseid);
    }
}
