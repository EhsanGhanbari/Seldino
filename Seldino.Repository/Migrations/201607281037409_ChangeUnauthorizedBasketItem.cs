namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUnauthorizedBasketItem : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Basket.Basket_UnauthorizedBasket", newName: "UnauthorizedBasket_BasketItem");
            RenameColumn(table: "Basket.UnauthorizedBasket_BasketItem", name: "UnauthorizedBasket", newName: "UnauthorizedBasketId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Basket.UnauthorizedBasket_BasketItem", name: "UnauthorizedBasketId", newName: "UnauthorizedBasket");
            RenameTable(name: "Basket.UnauthorizedBasket_BasketItem", newName: "Basket_UnauthorizedBasket");
        }
    }
}
