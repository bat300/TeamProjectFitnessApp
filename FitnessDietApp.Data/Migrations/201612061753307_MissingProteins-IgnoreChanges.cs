namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingProteinsIgnoreChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductsDiaries", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.ProductsDiaries", "Diary_Id", "dbo.Diaries");
            DropIndex("dbo.ProductsDiaries", new[] { "Products_Id" });
            DropIndex("dbo.ProductsDiaries", new[] { "Diary_Id" });
            CreateTable(
                "dbo.DiaryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Diary_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Diaries", t => t.Diary_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Diary_Id);
            
            AddColumn("dbo.Diaries", "PersonNorm_Id", c => c.Int());
            AddColumn("dbo.PersonNorms", "ProteinsLow", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "ProteinsUp", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "FatLow", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "FatUp", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "CarbohydratesLow", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "CarbohydratesUp", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "CaloriesLow", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "CaloriesUp", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Сalories", c => c.Double(nullable: false));
            CreateIndex("dbo.Diaries", "PersonNorm_Id");
            AddForeignKey("dbo.Diaries", "PersonNorm_Id", "dbo.PersonNorms", "Id");
            DropColumn("dbo.PersonNorms", "DateOfBegin");
            DropColumn("dbo.PersonNorms", "DateOfChange");
            DropTable("dbo.ProductsDiaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductsDiaries",
                c => new
                    {
                        Products_Id = c.Int(nullable: false),
                        Diary_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Products_Id, t.Diary_Id });
            
            AddColumn("dbo.PersonNorms", "DateOfChange", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonNorms", "DateOfBegin", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Diaries", "PersonNorm_Id", "dbo.PersonNorms");
            DropForeignKey("dbo.DiaryItems", "Diary_Id", "dbo.Diaries");
            DropForeignKey("dbo.DiaryItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.DiaryItems", new[] { "Diary_Id" });
            DropIndex("dbo.DiaryItems", new[] { "Product_Id" });
            DropIndex("dbo.Diaries", new[] { "PersonNorm_Id" });
            AlterColumn("dbo.Products", "Сalories", c => c.Int(nullable: false));
            DropColumn("dbo.PersonNorms", "CaloriesUp");
            DropColumn("dbo.PersonNorms", "CaloriesLow");
            DropColumn("dbo.PersonNorms", "CarbohydratesUp");
            DropColumn("dbo.PersonNorms", "CarbohydratesLow");
            DropColumn("dbo.PersonNorms", "FatUp");
            DropColumn("dbo.PersonNorms", "FatLow");
            DropColumn("dbo.PersonNorms", "ProteinsUp");
            DropColumn("dbo.PersonNorms", "ProteinsLow");
            DropColumn("dbo.Diaries", "PersonNorm_Id");
            DropTable("dbo.DiaryItems");
            CreateIndex("dbo.ProductsDiaries", "Diary_Id");
            CreateIndex("dbo.ProductsDiaries", "Products_Id");
            AddForeignKey("dbo.ProductsDiaries", "Diary_Id", "dbo.Diaries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductsDiaries", "Products_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
