namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        DocumentId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: true),
                        Price = c.Decimal(nullable: true, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: true, precision: 18, scale: 2),
                        taxRate = c.Decimal(nullable: true, precision: 18, scale: 2),
                        assemblyPrice = c.Decimal(nullable: true, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.DocumentId)
                .Index(t => t.ProductId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Articles", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Articles", new[] { "ProductId" });
            DropIndex("dbo.Articles", new[] { "DocumentId" });
            DropTable("dbo.Articles");
        }
    }
}
