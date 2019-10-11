namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivitesInfoes", "MadeActivitesId", "dbo.MadeActivites");
            DropIndex("dbo.ActivitesInfoes", new[] { "MadeActivitesId" });
            DropTable("dbo.ActivitesInfoes");
        }
    }
}
