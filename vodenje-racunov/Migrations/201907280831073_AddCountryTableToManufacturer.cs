namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryTableToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturers", "CountryId", c => c.Int(nullable: true));
            CreateIndex("dbo.Manufacturers", "CountryId");
            AddForeignKey("dbo.Manufacturers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            DropColumn("dbo.Manufacturers", "ManufacturerCountry");
        }
        
        public override void Down()
        {

        }
    }
}
