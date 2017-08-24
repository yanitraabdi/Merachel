namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "UserID", c => c.Int());
            AddColumn("dbo.Courses", "CoursePictureImageData", c => c.Binary());
            AddColumn("dbo.Courses", "CoursePictureMimeType", c => c.String());
            AddColumn("dbo.Events", "UserID", c => c.Int());
            CreateIndex("dbo.Blogs", "UserID");
            CreateIndex("dbo.Events", "UserID");
            AddForeignKey("dbo.Blogs", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Events", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.Blogs", "UserID", "dbo.Users");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Blogs", new[] { "UserID" });
            DropColumn("dbo.Events", "UserID");
            DropColumn("dbo.Courses", "CoursePictureMimeType");
            DropColumn("dbo.Courses", "CoursePictureImageData");
            DropColumn("dbo.Blogs", "UserID");
        }
    }
}
