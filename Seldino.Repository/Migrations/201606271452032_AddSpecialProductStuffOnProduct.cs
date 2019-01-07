namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialProductStuffOnProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "NotExist", c => c.Boolean(nullable: false));
            AddColumn("Product.Product", "IsNotInSpecialState", c => c.Boolean(nullable: false));
            AddColumn("Product.ProductSpecialState", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Product.ProductSpecialState", "Description");
            DropColumn("Product.Product", "IsNotInSpecialState");
            DropColumn("Product.Product", "NotExist");
        }
    }
}
