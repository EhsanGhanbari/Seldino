namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddVisitCountOnProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Product", "VisitCount", c => c.Int(nullable: false, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("Product.Product", "VisitCount");
        }
    }
}
