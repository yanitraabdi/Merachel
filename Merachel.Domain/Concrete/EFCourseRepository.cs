using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Abstract;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFCourseRepository : ICourseRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Course> Courses
        {
            get { return context.Courses; }
        }

        public void SaveCourse(Course course)
        {
            if (course.CourseID == 0)
            {
                course.CourseStatus = true;
                course.CourseDate = DateTime.Now;
                context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = context.Courses.Find(course.CourseID);
                if (dbEntry != null)
                {
                    dbEntry.CourseCategoryID = course.CourseCategoryID;
                    dbEntry.CourseDescription = course.CourseDescription;
                    dbEntry.CourseName = course.CourseName;
                    dbEntry.CoursePictureMimeType = course.CoursePictureMimeType;
                    dbEntry.CoursePictureImageData = course.CoursePictureImageData;
                    dbEntry.CourseStatus = true;
                }
            }
            context.SaveChanges();
        }

        public void SaveSimpleCourse(Course course)
        {
            if (course.CourseID == 0)
            {
                course.CourseStatus = true;
                course.CourseDate = DateTime.Now;
                context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = context.Courses.Find(course.CourseID);
                if (dbEntry != null)
                {
                    dbEntry.CourseCategoryID = course.CourseCategoryID;
                    dbEntry.CourseDescription = course.CourseDescription;
                    dbEntry.CourseName = course.CourseName;
                    dbEntry.CourseStatus = true;
                }
            }
            context.SaveChanges();
        }

        public Course DeleteCourse(int courseid)
        {
            Course dbEntry = context.Courses.Find(courseid);
            if (dbEntry != null)
            {
                dbEntry.CourseStatus = false;
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
