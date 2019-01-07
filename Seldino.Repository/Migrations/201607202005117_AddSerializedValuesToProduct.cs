namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSerializedValuesToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "OldPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Product.Product", "OldDollarPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Product.Product", "SerializedTags", c => c.String(maxLength: 500));
            AddColumn("Product.Product", "SerializedColors", c => c.String(maxLength: 500));
            AddColumn("Product.Product", "SerializedSizes", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("Product.Product", "SerializedSizes");
            DropColumn("Product.Product", "SerializedColors");
            DropColumn("Product.Product", "SerializedTags");
            DropColumn("Product.Product", "OldDollarPrice");
            DropColumn("Product.Product", "OldPrice");
        }
    }
}
