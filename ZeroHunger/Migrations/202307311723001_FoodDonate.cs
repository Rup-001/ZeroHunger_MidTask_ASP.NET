namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodDonate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodDonates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        Status = c.DateTime(nullable: false),
                        ResId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resturants", t => t.ResId, cascadeDelete: true)
                .Index(t => t.ResId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodDonates", "ResId", "dbo.Resturants");
            DropIndex("dbo.FoodDonates", new[] { "ResId" });
            DropTable("dbo.FoodDonates");
        }
    }
}
