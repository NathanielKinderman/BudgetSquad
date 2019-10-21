namespace BudgetSquad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolboolbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MadeActivites", "CheckingInToActivity", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MadeActivites", "CheckingInToActivity");
        }
    }
}
