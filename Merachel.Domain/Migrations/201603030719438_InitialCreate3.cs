namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        EmployeeSpecial = c.String(nullable: false, maxLength: 100),
                        EmployeeDescription = c.String(nullable: false),
                        EmployeeDate = c.DateTime(nullable: false),
                        EmployeeImageData = c.Binary(),
                        EmployeeMimeType = c.String(),
                        EmployeeStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        TestimonialContent = c.String(nullable: false),
                        TestimonialUser = c.String(nullable: false, maxLength: 80),
                        TestimonialDate = c.DateTime(nullable: false),
                        TestimonialImageData = c.Binary(),
                        TestimonialMimeType = c.String(),
                        TestimonialStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
            DropColumn("dbo.Events", "EventDatePromote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventDatePromote", c => c.DateTime(nullable: false));
            DropTable("dbo.Testimonials");
            DropTable("dbo.Employees");
        }
    }
}
