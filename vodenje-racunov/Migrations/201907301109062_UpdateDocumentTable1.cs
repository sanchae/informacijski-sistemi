namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocumentTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "OfferDate", c => c.DateTime());
            AlterColumn("dbo.Documents", "OfferValidityDays", c => c.Int());
            AlterColumn("dbo.Documents", "OfferDateOfOrder", c => c.Int());
            AlterColumn("dbo.Documents", "InvoiceDate", c => c.DateTime());
            AlterColumn("dbo.Documents", "InvoiceServiceFrom", c => c.DateTime());
            AlterColumn("dbo.Documents", "InvoiceServiceUntil", c => c.DateTime());
            AlterColumn("dbo.Documents", "InvoiceDateOfMaturity", c => c.DateTime());
            AlterColumn("dbo.Documents", "InvoiceDateOfOrder", c => c.DateTime());
            AlterColumn("dbo.Documents", "DeliveryNoteDate", c => c.DateTime());
            AlterColumn("dbo.Documents", "TotalExcludingVAT", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "DiscountPercent", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "DiscountAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "AmountExcludingVAT", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "AmountIncludingVAT", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "PaidAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "AmountIncludingVAT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "AmountExcludingVAT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "DiscountPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "TotalExcludingVAT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Documents", "DeliveryNoteDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "InvoiceDateOfOrder", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "InvoiceDateOfMaturity", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "InvoiceServiceUntil", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "InvoiceServiceFrom", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "InvoiceDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "OfferDateOfOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "OfferValidityDays", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "OfferDate", c => c.DateTime(nullable: false));
        }
    }
}
