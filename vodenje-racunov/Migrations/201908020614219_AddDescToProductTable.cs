namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescToProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
        }
    }
}
