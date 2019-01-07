namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettingConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Setting.BannerSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsAutoPublished = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.BasicSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        WebsiteTitle = c.String(nullable: false, maxLength: 100),
                        WebsiteUrl = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.BasketSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        EmailNotificationEnabled = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.BlogSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsCommentAutoPublished = c.Boolean(nullable: false),
                        CommentLength = c.Int(nullable: false),
                        CommentIntervalTime = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.DiscountSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.DocumentSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.OrderSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.ProductSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsAutoPublished = c.Boolean(nullable: false),
                        ImagePrefixAddress = c.String(nullable: false, maxLength: 300),
                        IsCommentAutoPublished = c.Boolean(nullable: false),
                        CommentLength = c.Int(nullable: false),
                        CommentIntervalTime = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.StoreSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsAutoPublished = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Setting.Setting", "BannerSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "BasicSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "BasketSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "BlogSettingId", c => c.Guid());
            AddColumn("Setting.Setting", "DiscountSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "DocumentSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "OrderSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "ProductSettingId", c => c.Guid(nullable: false));
            AddColumn("Setting.Setting", "StoreSettingId", c => c.Guid(nullable: false));
            CreateIndex("Setting.Setting", "BannerSettingId");
            CreateIndex("Setting.Setting", "BasicSettingId");
            CreateIndex("Setting.Setting", "BasketSettingId");
            CreateIndex("Setting.Setting", "BlogSettingId");
            CreateIndex("Setting.Setting", "DiscountSettingId");
            CreateIndex("Setting.Setting", "DocumentSettingId");
            CreateIndex("Setting.Setting", "OrderSettingId");
            CreateIndex("Setting.Setting", "ProductSettingId");
            CreateIndex("Setting.Setting", "StoreSettingId");
            AddForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "BlogSettingId", "Setting.BlogSetting", "Id");
            AddForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting", "Id", cascadeDelete: true);
            AddForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Setting.Setting", "StoreSettingId", "Setting.StoreSetting");
            DropForeignKey("Setting.Setting", "ProductSettingId", "Setting.ProductSetting");
            DropForeignKey("Setting.Setting", "OrderSettingId", "Setting.OrderSetting");
            DropForeignKey("Setting.Setting", "DocumentSettingId", "Setting.DocumentSetting");
            DropForeignKey("Setting.Setting", "DiscountSettingId", "Setting.DiscountSetting");
            DropForeignKey("Setting.Setting", "BlogSettingId", "Setting.BlogSetting");
            DropForeignKey("Setting.Setting", "BasketSettingId", "Setting.BasketSetting");
            DropForeignKey("Setting.Setting", "BasicSettingId", "Setting.BasicSetting");
            DropForeignKey("Setting.Setting", "BannerSettingId", "Setting.BannerSetting");
            DropIndex("Setting.Setting", new[] { "StoreSettingId" });
            DropIndex("Setting.Setting", new[] { "ProductSettingId" });
            DropIndex("Setting.Setting", new[] { "OrderSettingId" });
            DropIndex("Setting.Setting", new[] { "DocumentSettingId" });
            DropIndex("Setting.Setting", new[] { "DiscountSettingId" });
            DropIndex("Setting.Setting", new[] { "BlogSettingId" });
            DropIndex("Setting.Setting", new[] { "BasketSettingId" });
            DropIndex("Setting.Setting", new[] { "BasicSettingId" });
            DropIndex("Setting.Setting", new[] { "BannerSettingId" });
            DropColumn("Setting.Setting", "StoreSettingId");
            DropColumn("Setting.Setting", "ProductSettingId");
            DropColumn("Setting.Setting", "OrderSettingId");
            DropColumn("Setting.Setting", "DocumentSettingId");
            DropColumn("Setting.Setting", "DiscountSettingId");
            DropColumn("Setting.Setting", "BlogSettingId");
            DropColumn("Setting.Setting", "BasketSettingId");
            DropColumn("Setting.Setting", "BasicSettingId");
            DropColumn("Setting.Setting", "BannerSettingId");
            DropTable("Setting.StoreSetting");
            DropTable("Setting.ProductSetting");
            DropTable("Setting.OrderSetting");
            DropTable("Setting.DocumentSetting");
            DropTable("Setting.DiscountSetting");
            DropTable("Setting.BlogSetting");
            DropTable("Setting.BasketSetting");
            DropTable("Setting.BasicSetting");
            DropTable("Setting.BannerSetting");
        }
    }
}
