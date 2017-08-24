namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogPictureImageData", c => c.Binary());
            AddColumn("dbo.Blogs", "BlogPictureMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogPictureMimeType");
            DropColumn("dbo.Blogs", "BlogPictureImageData");
        }
    }
}
