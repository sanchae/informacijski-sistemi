namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferDateOfOrderToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "OfferDateOfOrder", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "OfferDateOfOrder", c => c.Int());
        }
    }
}
