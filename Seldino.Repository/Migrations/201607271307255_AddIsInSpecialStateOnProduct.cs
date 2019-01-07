namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddIsInSpecialStateOnProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "IsInSpecialState", c => c.Boolean(nullable: false, defaultValue: false));
            DropColumn("Product.Product", "IsNotInSpecialState");
        }

        public override void Down()
        {
            AddColumn("Product.Product", "IsNotInSpecialState", c => c.Boolean(nullable: false));
            DropColumn("Product.Product", "IsInSpecialState");
        }
    }
}
