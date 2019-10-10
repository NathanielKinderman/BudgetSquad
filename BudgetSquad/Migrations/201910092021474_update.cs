namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreateEvents", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.MadeActivites", "CreateEventId", "dbo.CreateEvents");
            DropIndex("dbo.CreateEvents", new[] { "PlannerId" });
            DropIndex("dbo.MadeActivites", new[] { "CreateEventId" });
            AddColumn("dbo.CreateEvents", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.MadeActivites", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CreateEvents", "ApplicationUserId");
            CreateIndex("dbo.MadeActivites", "ApplicationUserId");
            AddForeignKey("dbo.CreateEvents", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MadeActivites", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.CreateEvents", "PlannerId");
            DropColumn("dbo.MadeActivites", "CreateEventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MadeActivites", "CreateEventId", c => c.Int(nullable: false));
            AddColumn("dbo.CreateEvents", "PlannerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MadeActivites", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CreateEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MadeActivites", new[] { "ApplicationUserId" });
            DropIndex("dbo.CreateEvents", new[] { "ApplicationUserId" });
            DropColumn("dbo.MadeActivites", "ApplicationUserId");
            DropColumn("dbo.CreateEvents", "ApplicationUserId");
            CreateIndex("dbo.MadeActivites", "CreateEventId");
            CreateIndex("dbo.CreateEvents", "PlannerId");
            AddForeignKey("dbo.MadeActivites", "CreateEventId", "dbo.CreateEvents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CreateEvents", "PlannerId", "dbo.Planners", "Id", cascadeDelete: true);
        }
    }
}
