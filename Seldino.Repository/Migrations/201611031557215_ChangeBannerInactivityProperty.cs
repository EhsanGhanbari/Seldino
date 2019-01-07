namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBannerInactivityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("Banner.Banner", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("Banner.Banner", "IsInactive");
        }
        
        public override void Down()
        {
            AddColumn("Banner.Banner", "IsInactive", c => c.Boolean(nullable: false));
            DropColumn("Banner.Banner", "IsActive");
        }
    }
}
