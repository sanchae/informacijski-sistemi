namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        RegistrationNumber = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        taxNumber = c.String(),
                        taxPayer = c.Boolean(nullable: false),
                        StreetName = c.String(),
                        StreetNumber = c.String(),
                        PostNumber = c.String(),
                        City = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropIndex("dbo.Clients", new[] { "CountryId" });
            DropTable("dbo.Clients");
        }
    }
}
