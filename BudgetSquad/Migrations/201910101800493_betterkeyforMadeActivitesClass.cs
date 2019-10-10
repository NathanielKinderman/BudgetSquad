namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class betterkeyforMadeActivitesClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MadeActivites", "EventsName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MadeActivites", "EventsName");
        }
    }
}
