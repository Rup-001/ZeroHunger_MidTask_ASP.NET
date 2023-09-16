namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodDonates", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodDonates", "Status", c => c.DateTime(nullable: false));
        }
    }
}
