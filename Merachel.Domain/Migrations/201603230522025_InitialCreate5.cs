namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserRole", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserRole", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
