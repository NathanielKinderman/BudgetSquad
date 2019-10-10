namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class betterkey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreateEvents", "EventsName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreateEvents", "EventsName", c => c.String());
        }
    }
}
