namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIsActiveFieldOnNotifiaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("Notification.Notification", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("Notification.Notification", "IsTerminated");
        }
        
        public override void Down()
        {
            AddColumn("Notification.Notification", "IsTerminated", c => c.Boolean(nullable: false));
            DropColumn("Notification.Notification", "IsActive");
        }
    }
}
