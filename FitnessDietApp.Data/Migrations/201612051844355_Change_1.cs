namespace FitnessDietApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_1 : DbMigration
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
            
            AddColumn("dbo.PersonNorms", "Proteins", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "Fat", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "Carbohydrates", c => c.Double(nullable: false));
            AddColumn("dbo.PersonNorms", "Сalories", c => c.Int(nullable: false));
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
            
            DropForeignKey("dbo.DiaryItems", "Diary_Id", "dbo.Diaries");
            DropForeignKey("dbo.DiaryItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.DiaryItems", new[] { "Diary_Id" });
            DropIndex("dbo.DiaryItems", new[] { "Product_Id" });
            DropColumn("dbo.PersonNorms", "Сalories");
            DropColumn("dbo.PersonNorms", "Carbohydrates");
            DropColumn("dbo.PersonNorms", "Fat");
            DropColumn("dbo.PersonNorms", "Proteins");
            DropTable("dbo.DiaryItems");
            CreateIndex("dbo.ProductsDiaries", "Diary_Id");
            CreateIndex("dbo.ProductsDiaries", "Products_Id");
            AddForeignKey("dbo.ProductsDiaries", "Diary_Id", "dbo.Diaries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductsDiaries", "Products_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
