namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MadeActivites", "TypeOfActivity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MadeActivites", "TypeOfActivity", c => c.String());
        }
    }
}
