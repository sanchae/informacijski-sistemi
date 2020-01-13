namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductVariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "ShortName", c => c.String());
            AddColumn("dbo.Products", "PurchasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "SellingPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "WarrantyInMonths", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "ProductShortName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductShortName", c => c.String());
            AddColumn("dbo.Products", "ProductName", c => c.String());
            DropColumn("dbo.Products", "WarrantyInMonths");
            DropColumn("dbo.Products", "SellingPrice");
            DropColumn("dbo.Products", "PurchasePrice");
            DropColumn("dbo.Products", "ShortName");
            DropColumn("dbo.Products", "Name");
        }
    }
}
