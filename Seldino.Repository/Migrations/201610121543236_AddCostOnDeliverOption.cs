namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostOnDeliverOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("Shipping.ShippingService", "Code", c => c.String(maxLength: 4000));
            AddColumn("Shipping.ShippingService", "Description", c => c.String(maxLength: 4000));
            AddColumn("Shipping.ShippingService", "CourierId", c => c.Guid());
            AddColumn("Shipping.Courier", "Name", c => c.String(maxLength: 4000));
            AddColumn("Shipping.DeliveryOption", "FreeDeliveryThreshold", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Shipping.DeliveryOption", "Cost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("Shipping.DeliveryOption", "DeliveryTime", c => c.Byte());
            AddColumn("Shipping.DeliveryOption", "ShippingServiceId", c => c.Guid());
            AlterColumn("Shipping.DeliveryOption", "Id", c => c.Guid(nullable: false, identity: true));
            CreateIndex("Shipping.ShippingService", "CourierId");
            CreateIndex("Shipping.DeliveryOption", "ShippingServiceId");
            AddForeignKey("Shipping.ShippingService", "CourierId", "Shipping.Courier", "Id");
            AddForeignKey("Shipping.DeliveryOption", "ShippingServiceId", "Shipping.ShippingService", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Shipping.DeliveryOption", "ShippingServiceId", "Shipping.ShippingService");
            DropForeignKey("Shipping.ShippingService", "CourierId", "Shipping.Courier");
            DropIndex("Shipping.DeliveryOption", new[] { "ShippingServiceId" });
            DropIndex("Shipping.ShippingService", new[] { "CourierId" });
            AlterColumn("Shipping.DeliveryOption", "Id", c => c.Guid(nullable: false));
            DropColumn("Shipping.DeliveryOption", "ShippingServiceId");
            DropColumn("Shipping.DeliveryOption", "DeliveryTime");
            DropColumn("Shipping.DeliveryOption", "Cost");
            DropColumn("Shipping.DeliveryOption", "FreeDeliveryThreshold");
            DropColumn("Shipping.Courier", "Name");
            DropColumn("Shipping.ShippingService", "CourierId");
            DropColumn("Shipping.ShippingService", "Description");
            DropColumn("Shipping.ShippingService", "Code");
        }
    }
}
