namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductVariables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Byte(nullable: false, identity: true),
                        ManufacturerName = c.String(nullable: false),
                        ManufacturerStreetName = c.String(),
                        ManufacturerStreetNumber = c.String(),
                        ManufacturerPostNumber = c.String(),
                        ManufacturerCity = c.String(),
                        ManufacturerCountry = c.String(),
                        ManufacturerEmail = c.String(),
                        ManufacturerPhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            AddColumn("dbo.Products", "ManufacturerId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ManufacturerId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "ManufacturerId");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
        }
    }
}
