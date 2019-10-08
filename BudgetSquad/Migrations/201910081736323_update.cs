namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreateEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventsName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        DateOfEvent = c.String(),
                        NumberOfMembers = c.Double(nullable: false),
                        TheBudgetOfEvent = c.String(),
                        PlannerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planners", t => t.PlannerId, cascadeDelete: true)
                .Index(t => t.PlannerId);
            
            CreateTable(
                "dbo.Planners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Budget = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.MadeActivites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfActivity = c.String(),
                        LocationOfActivity = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        City = c.String(),
                        State = c.String(),
                        TimeOfActivity = c.String(),
                        HowManyMembersInvolved = c.String(),
                        EstimatedCostOfActivity = c.Double(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreateEvents", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.PartyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PersonalBudget = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartyMembers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MadeActivites", "EventId", "dbo.CreateEvents");
            DropForeignKey("dbo.CreateEvents", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.Planners", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PartyMembers", new[] { "ApplicationUserId" });
            DropIndex("dbo.MadeActivites", new[] { "EventId" });
            DropIndex("dbo.Planners", new[] { "ApplicationUserId" });
            DropIndex("dbo.CreateEvents", new[] { "PlannerId" });
            DropTable("dbo.PartyMembers");
            DropTable("dbo.MadeActivites");
            DropTable("dbo.Planners");
            DropTable("dbo.CreateEvents");
        }
    }
}
