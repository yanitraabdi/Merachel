using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merachel.Domain.Entities;

namespace Merachel.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionPicture> CollectionPictures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CoursePrice> CoursePrices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventPrice> EventPrices { get; set; }
        public DbSet<EventPicture> EventPictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Lookup> Lookups { get; set; }
    }
}
