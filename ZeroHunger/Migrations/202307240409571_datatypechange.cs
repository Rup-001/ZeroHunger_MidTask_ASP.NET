namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Pass", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Pass", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.Int(nullable: false));
        }
    }
}
