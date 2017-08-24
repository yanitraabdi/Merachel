namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        BlogCategoryID = c.Int(nullable: false, identity: true),
                        BlogCategoryName = c.String(nullable: false, maxLength: 100),
                        BlogCategoryDate = c.DateTime(nullable: false),
                        BlogCategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogCategoryID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(nullable: false, maxLength: 200),
                        BlogContent = c.String(nullable: false),
                        BlogDate = c.DateTime(nullable: false),
                        BlogStatus = c.Boolean(nullable: false),
                        BlogCategoryID = c.Int(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.BlogCategoryID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserFullName = c.String(nullable: false, maxLength: 100),
                        UserEmail = c.String(nullable: false, maxLength: 30),
                        UserPassword = c.String(nullable: false, maxLength: 30),
                        UserPhone = c.String(nullable: false, maxLength: 30),
                        UserAddress = c.String(maxLength: 250),
                        UserRole = c.String(nullable: false, maxLength: 30),
                        UserJoinDate = c.DateTime(nullable: false),
                        UserStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.CollectionPictures",
                c => new
                    {
                        CollectionPictureID = c.Int(nullable: false, identity: true),
                        CollectionPictureImageData = c.Binary(),
                        CollectionPictureMimeType = c.String(),
                        CollectionPictureStatus = c.Boolean(nullable: false),
                        CollectionID = c.Int(),
                    })
                .PrimaryKey(t => t.CollectionPictureID)
                .ForeignKey("dbo.Collections", t => t.CollectionID)
                .Index(t => t.CollectionID);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        CollectionTitle = c.String(nullable: false, maxLength: 100),
                        CollectionDate = c.DateTime(nullable: false),
                        CollectionStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionID);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        CourseCategoryID = c.Int(nullable: false, identity: true),
                        CourseCategoryName = c.String(nullable: false, maxLength: 100),
                        CourseCategoryDescription = c.String(nullable: false),
                        CourseCategoryDate = c.DateTime(nullable: false),
                        CourseCategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseCategoryID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        CourseDescription = c.String(nullable: false),
                        CoursePictureImageData = c.Binary(),
                        CoursePictureMimeType = c.String(),
                        CourseDate = c.DateTime(nullable: false),
                        CourseStatus = c.Boolean(nullable: false),
                        CourseCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryID)
                .Index(t => t.CourseCategoryID);
            
            CreateTable(
                "dbo.CoursePrices",
                c => new
                    {
                        CoursePriceID = c.Int(nullable: false, identity: true),
                        CoursePriceName = c.String(nullable: false, maxLength: 100),
                        CoursePriceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoursePriceDescription = c.String(nullable: false),
                        CoursePriceDate = c.DateTime(nullable: false),
                        CoursePriceStatus = c.Boolean(nullable: false),
                        CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.CoursePriceID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.EventPictures",
                c => new
                    {
                        EventPictureID = c.Int(nullable: false, identity: true),
                        EventPictureImageData = c.Binary(),
                        EventPictureMimeType = c.String(),
                        EventPictureStatus = c.Boolean(nullable: false),
                        EventID = c.Int(),
                    })
                .PrimaryKey(t => t.EventPictureID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 100),
                        EventDescription = c.String(nullable: false),
                        EventLocation = c.String(nullable: false, maxLength: 200),
                        EventHost = c.String(maxLength: 100),
                        EventTimeStart = c.DateTime(nullable: false),
                        EventTimeEnd = c.DateTime(nullable: false),
                        EventDateCreated = c.DateTime(nullable: false),
                        EventDatePromote = c.DateTime(nullable: false),
                        EventBeginDate = c.DateTime(nullable: false),
                        EventEndDate = c.DateTime(nullable: false),
                        UserID = c.Int(),
                        EventStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.EventPrices",
                c => new
                    {
                        EventPriceID = c.Int(nullable: false, identity: true),
                        EventPriceName = c.String(nullable: false, maxLength: 100),
                        EventPriceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventPriceQuota = c.String(nullable: false, maxLength: 5),
                        EventPriceDate = c.DateTime(nullable: false),
                        EventPriceStatus = c.Boolean(nullable: false),
                        EventID = c.Int(),
                    })
                .PrimaryKey(t => t.EventPriceID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropForeignKey("dbo.EventPrices", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventPictures", "EventID", "dbo.Events");
            DropForeignKey("dbo.CoursePrices", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseCategoryID", "dbo.CourseCategories");
            DropForeignKey("dbo.CollectionPictures", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Blogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Blogs", "BlogCategoryID", "dbo.BlogCategories");
            DropIndex("dbo.EventPrices", new[] { "EventID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.EventPictures", new[] { "EventID" });
            DropIndex("dbo.CoursePrices", new[] { "CourseID" });
            DropIndex("dbo.Courses", new[] { "CourseCategoryID" });
            DropIndex("dbo.CollectionPictures", new[] { "CollectionID" });
            DropIndex("dbo.Blogs", new[] { "UserID" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryID" });
            DropTable("dbo.EventPrices");
            DropTable("dbo.Events");
            DropTable("dbo.EventPictures");
            DropTable("dbo.CoursePrices");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Collections");
            DropTable("dbo.CollectionPictures");
            DropTable("dbo.Users");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
        }
    }
}
