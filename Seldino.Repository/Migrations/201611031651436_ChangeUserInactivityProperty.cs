namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserInactivityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("Membership.User", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("Membership.User", "IsInactive");
        }
        
        public override void Down()
        {
            AddColumn("Membership.User", "IsInactive", c => c.Boolean(nullable: false));
            DropColumn("Membership.User", "IsActive");
        }
    }
}
