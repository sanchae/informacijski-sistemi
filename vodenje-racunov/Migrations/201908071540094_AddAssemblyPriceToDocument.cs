namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssemblyPriceToDocument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "AssemblyPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "AssemblyPrice");
        }
    }
}
