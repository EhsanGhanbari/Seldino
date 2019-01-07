namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMetaKeywordOnProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "MetKeywords", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("Product.Product", "MetKeywords");
        }
    }
}
