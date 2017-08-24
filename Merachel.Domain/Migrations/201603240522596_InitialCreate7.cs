namespace Merachel.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserFullName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "UserPhone", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserPhone", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "UserFullName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
