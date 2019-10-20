namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivitesInfoes",
                c => new
                    {
                        InfoId = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        CostOfActivity = c.Double(nullable: false),
                        MadeActivitesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InfoId)
                .ForeignKey("dbo.MadeActivites", t => t.MadeActivitesId, cascadeDelete: true)
                .Index(t => t.MadeActivitesId);
            
            CreateTable(
                "dbo.MadeActivites",
                c => new
                    {
                        MadeActivitesId = c.Int(nullable: false, identity: true),
                        EventsName = c.String(nullable: false),
                        NameOfActivity = c.String(),
                        LocationOfActivity = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        City = c.String(),
                        State = c.String(),
                        TimeOfActivity = c.String(),
                        HowManyMembersInvolved = c.String(),
                        EstimatedCostOfActivity = c.Double(nullable: false),
                        PlannerId = c.Int(),
                    })
                .PrimaryKey(t => t.MadeActivitesId)
                .ForeignKey("dbo.Planners", t => t.PlannerId)
                .Index(t => t.PlannerId);
            
            CreateTable(
                "dbo.Planners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmailAddress = c.String(),
                        Budget = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CreateEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventsName = c.String(nullable: false),
                        NameOfPlanner = c.String(),
                        City = c.String(),
                        State = c.String(),
                        DateOfEvent = c.String(),
                        NumberOfMembers = c.Double(nullable: false),
                        TheBudgetOfEvent = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.PartyMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PersonalBudget = c.String(),
                        IsGoingToEvent = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PartyMembers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CreateEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ActivitesInfoes", "MadeActivitesId", "dbo.MadeActivites");
            DropForeignKey("dbo.MadeActivites", "PlannerId", "dbo.Planners");
            DropForeignKey("dbo.Planners", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PartyMembers", new[] { "ApplicationUserId" });
            DropIndex("dbo.CreateEvents", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Planners", new[] { "ApplicationUserId" });
            DropIndex("dbo.MadeActivites", new[] { "PlannerId" });
            DropIndex("dbo.ActivitesInfoes", new[] { "MadeActivitesId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PartyMembers");
            DropTable("dbo.CreateEvents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Planners");
            DropTable("dbo.MadeActivites");
            DropTable("dbo.ActivitesInfoes");
        }
    }
}
