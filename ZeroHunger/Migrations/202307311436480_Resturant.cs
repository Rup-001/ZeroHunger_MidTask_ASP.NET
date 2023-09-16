namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resturant : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Donors", newName: "Resturants");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Resturants", newName: "Donors");
        }
    }
}
