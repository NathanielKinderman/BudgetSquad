namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MadeActivites", "CreateEventId", "dbo.CreateEvents");
            DropIndex("dbo.MadeActivites", new[] { "CreateEventId" });
            AddColumn("dbo.MadeActivites", "PlannerId", c => c.Int(nullable: false));
            CreateIndex("dbo.MadeActivites", "PlannerId");
            AddForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners", "Id", cascadeDelete: true);
            DropColumn("dbo.MadeActivites", "CreateEventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MadeActivites", "CreateEventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            DropColumn("dbo.MadeActivites", "PlannerId");
            CreateIndex("dbo.MadeActivites", "CreateEventId");
            AddForeignKey("dbo.MadeActivites", "CreateEventId", "dbo.CreateEvents", "EventId", cascadeDelete: true);
        }
    }
}
