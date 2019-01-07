namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Payment.Invoice",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        PaymentId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(nullable: false, maxLength: 4000),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Payment.Payment", t => t.PaymentId)
                .ForeignKey("Membership.User", t => t.UserId)
                .Index(t => t.PaymentId)
                .Index(t => t.UserId);
            
            AddColumn("Notification.Message", "NotificationMessageType", c => c.Byte(nullable: false));
            AlterColumn("Payment.Payment", "TransactionId", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("Payment.Payment", "Merchant", c => c.String(nullable: false, maxLength: 4000));
            DropColumn("Notification.Message", "MessageType");
        }
        
        public override void Down()
        {
            AddColumn("Notification.Message", "MessageType", c => c.Byte(nullable: false));
            DropForeignKey("Payment.Invoice", "UserId", "Membership.User");
            DropForeignKey("Payment.Invoice", "PaymentId", "Payment.Payment");
            DropIndex("Payment.Invoice", new[] { "UserId" });
            DropIndex("Payment.Invoice", new[] { "PaymentId" });
            AlterColumn("Payment.Payment", "Merchant", c => c.String());
            AlterColumn("Payment.Payment", "TransactionId", c => c.String());
            DropColumn("Notification.Message", "NotificationMessageType");
            DropTable("Payment.Invoice");
        }
    }
}
