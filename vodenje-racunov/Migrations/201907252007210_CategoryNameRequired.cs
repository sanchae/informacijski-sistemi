using System.Dynamic;

namespace vodenje_racunov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryNameRequired : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Categories WHERE CategoryId = 5");
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
