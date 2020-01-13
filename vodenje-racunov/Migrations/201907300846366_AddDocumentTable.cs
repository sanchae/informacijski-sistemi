namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        OfferDate = c.DateTime(nullable: false),
                        OfferValidityDays = c.Int(nullable: false),
                        OfferDateOfOrder = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceServiceFrom = c.DateTime(nullable: false),
                        InvoiceServiceUntil = c.DateTime(nullable: false),
                        InvoiceDateOfMaturity = c.DateTime(nullable: false),
                        InvoiceDateOfOrder = c.DateTime(nullable: false),
                        DeliveryNoteDate = c.DateTime(nullable: false),
                        TotalExcludingVAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountExcludingVAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountIncludingVAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "ClientId", "dbo.Clients");
            DropIndex("dbo.Documents", new[] { "ClientId" });
            DropTable("dbo.Documents");
        }
    }
}
