namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKPKUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodDonates", "EmpId", c => c.Int());
            CreateIndex("dbo.FoodDonates", "EmpId");
            AddForeignKey("dbo.FoodDonates", "EmpId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodDonates", "EmpId", "dbo.Employees");
            DropIndex("dbo.FoodDonates", new[] { "EmpId" });
            DropColumn("dbo.FoodDonates", "EmpId");
        }
    }
}
