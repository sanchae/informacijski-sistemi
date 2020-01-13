namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocumentTable : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Documents");
            CreateTable(
                "dbo.Documents",
                c => new
                {
                    DocumentId = c.Int(nullable: false, identity: true),
                    ClientId = c.Int(nullable: false),
                    OfferDate = c.DateTime(nullable: true),
                    OfferValidityDays = c.Int(nullable: true),
                    OfferDateOfOrder = c.Int(nullable: true),
                    InvoiceDate = c.DateTime(nullable: true),
                    InvoiceServiceFrom = c.DateTime(nullable: true),
                    InvoiceServiceUntil = c.DateTime(nullable: true),
                    InvoiceDateOfMaturity = c.DateTime(nullable: true),
                    InvoiceDateOfOrder = c.DateTime(nullable: true),
                    DeliveryNoteDate = c.DateTime(nullable: true),
                    TotalExcludingVAT = c.Decimal(nullable: true, precision: 18, scale: 2),
                    DiscountPercent = c.Decimal(nullable: true, precision: 18, scale: 2),
                    DiscountAmount = c.Decimal(nullable: true, precision: 18, scale: 2),
                    AmountExcludingVAT = c.Decimal(nullable: true, precision: 18, scale: 2),
                    AmountIncludingVAT = c.Decimal(nullable: true, precision: 18, scale: 2),
                    PaidAmount = c.Decimal(nullable: true, precision: 18, scale: 2),
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
