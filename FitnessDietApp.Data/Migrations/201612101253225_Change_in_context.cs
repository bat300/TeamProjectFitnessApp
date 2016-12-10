namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_in_context : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InfoProDaySummarisings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProteinsProDay = c.Double(nullable: false),
                        FatsProDay = c.Double(nullable: false),
                        CarbohydratesProDay = c.Double(nullable: false),
                        DeviationOfProteinsProDay = c.Double(nullable: false),
                        DeviationOfFatsProDay = c.Double(nullable: false),
                        DeviationOfCarbohydratesProDay = c.Double(nullable: false),
                        CalloriesProDay = c.Double(nullable: false),
                        DeviationOfCalloriesProDay = c.Double(nullable: false),
                        DaysDiary_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diaries", t => t.DaysDiary_Id)
                .Index(t => t.DaysDiary_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InfoProDaySummarisings", "DaysDiary_Id", "dbo.Diaries");
            DropIndex("dbo.InfoProDaySummarisings", new[] { "DaysDiary_Id" });
            DropTable("dbo.InfoProDaySummarisings");
        }
    }
}
