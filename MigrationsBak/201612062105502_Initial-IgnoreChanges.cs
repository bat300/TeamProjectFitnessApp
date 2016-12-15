namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialIgnoreChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonNorms", "Calories", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonNorms", "Calories");
        }
    }
}
