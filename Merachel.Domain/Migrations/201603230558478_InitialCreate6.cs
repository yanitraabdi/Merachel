namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserDescription", c => c.String(nullable: false));
        }
    }
}
