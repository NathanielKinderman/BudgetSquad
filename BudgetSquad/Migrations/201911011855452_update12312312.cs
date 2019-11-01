namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update12312312 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            AlterColumn("dbo.MadeActivites", "PlannerId", c => c.Int());
            CreateIndex("dbo.MadeActivites", "PlannerId");
            AddForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            AlterColumn("dbo.MadeActivites", "PlannerId", c => c.Int(nullable: false));
            CreateIndex("dbo.MadeActivites", "PlannerId");
            AddForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners", "Id", cascadeDelete: true);
        }
    }
}
