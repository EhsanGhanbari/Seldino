namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdduUnauthorizedBasket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Basket.UnauthorizedBasket",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CookieId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Basket.UnauthorizedBasketItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Product.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Basket.Basket_UnauthorizedBasket",
                c => new
                    {
                        UnauthorizedBasket = c.Guid(nullable: false),
                        BasketItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UnauthorizedBasket, t.BasketItemId })
                .ForeignKey("Basket.UnauthorizedBasket", t => t.UnauthorizedBasket, cascadeDelete: true)
                .ForeignKey("Basket.UnauthorizedBasketItem", t => t.BasketItemId, cascadeDelete: true)
                .Index(t => t.UnauthorizedBasket)
                .Index(t => t.BasketItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Basket.Basket_UnauthorizedBasket", "BasketItemId", "Basket.UnauthorizedBasketItem");
            DropForeignKey("Basket.Basket_UnauthorizedBasket", "UnauthorizedBasket", "Basket.UnauthorizedBasket");
            DropForeignKey("Basket.UnauthorizedBasketItem", "ProductId", "Product.Product");
            DropIndex("Basket.Basket_UnauthorizedBasket", new[] { "BasketItemId" });
            DropIndex("Basket.Basket_UnauthorizedBasket", new[] { "UnauthorizedBasket" });
            DropIndex("Basket.UnauthorizedBasketItem", new[] { "ProductId" });
            DropTable("Basket.Basket_UnauthorizedBasket");
            DropTable("Basket.UnauthorizedBasketItem");
            DropTable("Basket.UnauthorizedBasket");
        }
    }
}
