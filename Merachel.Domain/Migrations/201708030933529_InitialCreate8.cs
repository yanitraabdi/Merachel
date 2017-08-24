namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lookups",
                c => new
                    {
                        LookupID = c.Int(nullable: false, identity: true),
                        LookupCategory = c.String(nullable: false, maxLength: 100),
                        LookupCode = c.String(nullable: false, maxLength: 100),
                        LookupType = c.String(nullable: false, maxLength: 100),
                        LookupDescription = c.String(nullable: false, maxLength: 500),
                        LookupSequenceNumber = c.String(maxLength: 30),
                        LookupCreatedDate = c.DateTime(nullable: false),
                        LookupStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LookupID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lookups");
        }
    }
}
