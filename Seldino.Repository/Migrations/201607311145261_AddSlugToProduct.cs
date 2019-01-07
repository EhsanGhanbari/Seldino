namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlugToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "Slug", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("Product.Product", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("Product.Product", "Name", c => c.String(nullable: false, maxLength: 80));
            DropColumn("Product.Product", "Slug");
        }
    }
}
