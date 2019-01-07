namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeoSetting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting");
            DropForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting");
            DropForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting");
            DropForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting");
            DropForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting");
            DropForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting");
            DropForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting");
            DropForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting");
            DropIndex("Setting.Setting", new[] { "BannerSettingId" });
            DropIndex("Setting.Setting", new[] { "BasicSettingId" });
            DropIndex("Setting.Setting", new[] { "BasketSettingId" });
            DropIndex("Setting.Setting", new[] { "DiscountSettingId" });
            DropIndex("Setting.Setting", new[] { "DocumentSettingId" });
            DropIndex("Setting.Setting", new[] { "OrderSettingId" });
            DropIndex("Setting.Setting", new[] { "ProductSettingId" });
            DropIndex("Setting.Setting", new[] { "StoreSettingId" });
            CreateTable(
                "Setting.SeoSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DefaultTitle = c.String(maxLength: 100),
                        DefaultMetaKeywords = c.String(maxLength: 200),
                        DefaultMetaDescription = c.String(maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Setting.Setting", "SeoSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "BannerSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "BasicSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "BasketSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "DiscountSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "DocumentSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "OrderSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "ProductSettingId", c => c.Guid());
            AlterColumn("Setting.Setting", "StoreSettingId", c => c.Guid());
            CreateIndex("Setting.Setting", "SeoSettingId");
            CreateIndex("Setting.Setting", "BannerSettingId");
            CreateIndex("Setting.Setting", "BasicSettingId");
            CreateIndex("Setting.Setting", "BasketSettingId");
            CreateIndex("Setting.Setting", "DiscountSettingId");
            CreateIndex("Setting.Setting", "DocumentSettingId");
            CreateIndex("Setting.Setting", "OrderSettingId");
            CreateIndex("Setting.Setting", "ProductSettingId");
            CreateIndex("Setting.Setting", "StoreSettingId");
            AddForeignKey("Setting.Setting", "SeoSettingId", "Setting.SeoSetting", "Id");
            AddForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting", "Id");
            AddForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting", "Id");
            AddForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting", "Id");
            AddForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting", "Id");
            AddForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting", "Id");
            AddForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting", "Id");
            AddForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting", "Id");
            AddForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting");
            DropForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting");
            DropForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting");
            DropForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting");
            DropForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting");
            DropForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting");
            DropForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting");
            DropForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting");
            DropForeignKey("Setting.Setting", "SeoSettingId", "Setting.SeoSetting");
            DropIndex("Setting.Setting", new[] { "StoreSettingId" });
            DropIndex("Setting.Setting", new[] { "ProductSettingId" });
            DropIndex("Setting.Setting", new[] { "OrderSettingId" });
            DropIndex("Setting.Setting", new[] { "DocumentSettingId" });
            DropIndex("Setting.Setting", new[] { "DiscountSettingId" });
            DropIndex("Setting.Setting", new[] { "BasketSettingId" });
            DropIndex("Setting.Setting", new[] { "BasicSettingId" });
            DropIndex("Setting.Setting", new[] { "BannerSettingId" });
            DropIndex("Setting.Setting", new[] { "SeoSettingId" });
            AlterColumn("Setting.Setting", "StoreSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "ProductSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "OrderSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "DocumentSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "DiscountSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "BasketSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "BasicSettingId", c => c.Guid(nullable: false));
            AlterColumn("Setting.Setting", "BannerSettingId", c => c.Guid(nullable: false));
            DropColumn("Setting.Setting", "SeoSettingId");
            DropTable("Setting.SeoSetting");
            CreateIndex("Setting.Setting", "StoreSettingId");
            CreateIndex("Setting.Setting", "ProductSettingId");
            CreateIndex("Setting.Setting", "OrderSettingId");
            CreateIndex("Setting.Setting", "DocumentSettingId");
            CreateIndex("Setting.Setting", "DiscountSettingId");
            CreateIndex("Setting.Setting", "BasketSettingId");
            CreateIndex("Setting.Setting", "BasicSettingId");
            CreateIndex("Setting.Setting", "BannerSettingId");
            AddForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting", "Id", cascadeDelete: true);
        }
    }
}
