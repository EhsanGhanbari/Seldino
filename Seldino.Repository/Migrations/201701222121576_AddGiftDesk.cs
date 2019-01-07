namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGiftDesk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GiftDesk.GiftDesk",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsPrivate = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GiftDesk.GiftDesk_AcceptedUser",
                c => new
                    {
                        GiftDeskId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GiftDeskId, t.UserId })
                .ForeignKey("GiftDesk.GiftDesk", t => t.GiftDeskId, cascadeDelete: true)
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GiftDeskId)
                .Index(t => t.UserId);
            
            CreateTable(
                "GiftDesk.GiftDesk_Product",
                c => new
                    {
                        GiftDeskId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GiftDeskId, t.ProductId })
                .ForeignKey("GiftDesk.GiftDesk", t => t.GiftDeskId, cascadeDelete: true)
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.GiftDeskId)
                .Index(t => t.ProductId);
            
            AddColumn("Membership.User", "GiftDeskId", c => c.Guid());
            CreateIndex("Membership.User", "GiftDeskId");
            AddForeignKey("Membership.User", "GiftDeskId", "GiftDesk.GiftDesk", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Membership.User", "GiftDeskId", "GiftDesk.GiftDesk");
            DropForeignKey("GiftDesk.GiftDesk_Product", "ProductId", "Product.Product");
            DropForeignKey("GiftDesk.GiftDesk_Product", "GiftDeskId", "GiftDesk.GiftDesk");
            DropForeignKey("GiftDesk.GiftDesk_AcceptedUser", "UserId", "Membership.User");
            DropForeignKey("GiftDesk.GiftDesk_AcceptedUser", "GiftDeskId", "GiftDesk.GiftDesk");
            DropIndex("Membership.User", new[] { "GiftDeskId" });
            DropIndex("GiftDesk.GiftDesk_Product", new[] { "ProductId" });
            DropIndex("GiftDesk.GiftDesk_Product", new[] { "GiftDeskId" });
            DropIndex("GiftDesk.GiftDesk_AcceptedUser", new[] { "UserId" });
            DropIndex("GiftDesk.GiftDesk_AcceptedUser", new[] { "GiftDeskId" });
            DropColumn("Membership.User", "GiftDeskId");
            DropTable("GiftDesk.GiftDesk_Product");
            DropTable("GiftDesk.GiftDesk_AcceptedUser");
            DropTable("GiftDesk.GiftDesk");
        }
    }
}
