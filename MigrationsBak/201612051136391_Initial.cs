namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Proteins = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Сalories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Lifestyle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonNorms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfBegin = c.DateTime(nullable: false),
                        DateOfChange = c.DateTime(nullable: false),
                        Parametrs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonInfoes", t => t.Parametrs_Id)
                .Index(t => t.Parametrs_Id);
            
            CreateTable(
                "dbo.ProductsDiaries",
                c => new
                    {
                        Products_Id = c.Int(nullable: false),
                        Diary_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Products_Id, t.Diary_Id })
                .ForeignKey("dbo.Products", t => t.Products_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diaries", t => t.Diary_Id, cascadeDelete: true)
                .Index(t => t.Products_Id)
                .Index(t => t.Diary_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonNorms", "Parametrs_Id", "dbo.PersonInfoes");
            DropForeignKey("dbo.ProductsDiaries", "Diary_Id", "dbo.Diaries");
            DropForeignKey("dbo.ProductsDiaries", "Products_Id", "dbo.Products");
            DropIndex("dbo.ProductsDiaries", new[] { "Diary_Id" });
            DropIndex("dbo.ProductsDiaries", new[] { "Products_Id" });
            DropIndex("dbo.PersonNorms", new[] { "Parametrs_Id" });
            DropTable("dbo.ProductsDiaries");
            DropTable("dbo.PersonNorms");
            DropTable("dbo.PersonInfoes");
            DropTable("dbo.Products");
            DropTable("dbo.Diaries");
        }
    }
}
