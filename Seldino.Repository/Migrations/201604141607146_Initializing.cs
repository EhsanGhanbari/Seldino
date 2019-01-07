namespace Seldino.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initializing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Document.About",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Document.Picture",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Document.Guide",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Location.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AddressLine = c.String(nullable: false, maxLength: 200),
                        City = c.String(nullable: false, maxLength: 80),
                        ZipCode = c.String(nullable: false, maxLength: 20),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Location.Area",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Location.Region",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Location.City",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Location.State",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Location.Country",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Banner.BannerPicture",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Banner.Banner",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsInactive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PictureId = c.Guid(nullable: false),
                        BannerType = c.Byte(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Url = c.String(maxLength: 200),
                        IsConfirmed = c.Boolean(nullable: false),
                        Caption = c.String(maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Banner.BannerPicture", t => t.PictureId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "Membership.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 100),
                        IsInactive = c.Boolean(nullable: false),
                        ProfileId = c.Guid(),
                        BasketId = c.Guid(),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        StoreComment_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Store.StoreComment", t => t.StoreComment_Id)
                .ForeignKey("Basket.Basket", t => t.BasketId)
                .ForeignKey("Membership.Profile", t => t.ProfileId)
                .ForeignKey("Membership.Role", t => t.RoleName)
                .Index(t => t.StoreComment_Id)
                .Index(t => t.BasketId)
                .Index(t => t.ProfileId)
                .Index(t => t.RoleName);
            
            CreateTable(
                "Basket.Basket",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Basket.BasketItem",
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
                "Product.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        OriginalName = c.String(nullable: false, maxLength: 80),
                        IsInactive = c.Boolean(nullable: false),
                        IsUnavailable = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DollarPrice = c.Decimal(precision: 18, scale: 2),
                        Brand = c.String(maxLength: 50),
                        Category = c.String(nullable: false, maxLength: 50),
                        SpecialStateId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Product.ProductBrand", t => t.Brand)
                .ForeignKey("Product.ProductCategory", t => t.Category)
                .ForeignKey("Product.ProductSpecialState", t => t.SpecialStateId)
                .Index(t => t.Brand)
                .Index(t => t.Category)
                .Index(t => t.SpecialStateId);
            
            CreateTable(
                "Discount.Discount",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Percentage = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Stopped = c.Boolean(nullable: false),
                        DiscountLimitation = c.Byte(nullable: false),
                        DiscountType = c.Byte(nullable: false),
                        RequiresCouponCode = c.Boolean(nullable: false),
                        CouponCode = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductBrand",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        IconId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("Product.ProductIcon", t => t.IconId)
                .Index(t => t.IconId);
            
            CreateTable(
                "Product.ProductIcon",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductCategory",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        IconId = c.Guid(),
                        ParentCategory = c.String(maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("Product.ProductIcon", t => t.IconId)
                .ForeignKey("Product.ProductCategory", t => t.ParentCategory)
                .Index(t => t.IconId)
                .Index(t => t.ParentCategory);
            
            CreateTable(
                "Product.ProductAttribute",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductAttributeOption",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Product.ProductTag",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        IconId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("Product.ProductIcon", t => t.IconId)
                .Index(t => t.IconId);
            
            CreateTable(
                "Product.ProductSize",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Store.Store",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsInactive = c.Boolean(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 50),
                        DocumentId = c.Guid(),
                        LocationId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Document.Document", t => t.DocumentId)
                .ForeignKey("Location.Location", t => t.LocationId)
                .Index(t => t.DocumentId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "Document.Document",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RuleId = c.Guid(),
                        AboutId = c.Guid(),
                        GuideId = c.Guid(),
                        InformationId = c.Guid(),
                        IsDefault = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Document.About", t => t.AboutId)
                .ForeignKey("Document.Guide", t => t.GuideId)
                .ForeignKey("Document.Information", t => t.InformationId)
                .ForeignKey("Document.Rule", t => t.RuleId)
                .Index(t => t.AboutId)
                .Index(t => t.GuideId)
                .Index(t => t.InformationId)
                .Index(t => t.RuleId);
            
            CreateTable(
                "Document.Information",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Document.Rule",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Document.SocialMedia",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 200),
                        SocialMediaOptionName = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Document.SocialMediaOption", t => t.SocialMediaOptionName)
                .Index(t => t.SocialMediaOptionName);
            
            CreateTable(
                "Document.SocialMediaOption",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.Binary(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Membership.Favorite",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Location.Location",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 100),
                        StateName = c.String(nullable: false, maxLength: 100),
                        AddressId = c.Guid(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 15),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 15),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Location.Address", t => t.AddressId)
                .ForeignKey("Location.Country", t => t.CountryName)
                .ForeignKey("Location.State", t => t.StateName)
                .Index(t => t.AddressId)
                .Index(t => t.CountryName)
                .Index(t => t.StateName);
            
            CreateTable(
                "Store.StorePicture",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Store.StoreComment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false, maxLength: 150),
                        ParentId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Store.StoreComment", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Order.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ShippingCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingServiceId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        PaymentId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Guid(),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Location.Location", t => t.LocationId)
                .ForeignKey("Payment.Payment", t => t.PaymentId)
                .ForeignKey("Shipping.ShippingService", t => t.ShippingServiceId)
                .ForeignKey("Membership.User", t => t.User_Id)
                .ForeignKey("Product.Product", t => t.Product_Id)
                .Index(t => t.LocationId)
                .Index(t => t.PaymentId)
                .Index(t => t.ShippingServiceId)
                .Index(t => t.User_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "Order.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Payment.Payment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        TransactionId = c.String(),
                        Merchant = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Byte(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Shipping.ShippingService",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductColor",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(),
                        IconId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("Product.ProductIcon", t => t.IconId)
                .Index(t => t.IconId);
            
            CreateTable(
                "Product.ProductComment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false, maxLength: 150),
                        ParentId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Product.ProductComment", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Product.ProductPicture",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductSpecialState",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Blog.BlogComment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false, maxLength: 150),
                        ParentId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.BlogComment", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Blog.BlogPost",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 300),
                        Body = c.String(nullable: false),
                        UrlSlug = c.String(nullable: false, maxLength: 300),
                        Category = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.BlogCategory", t => t.Category)
                .Index(t => t.Category);
            
            CreateTable(
                "Blog.BlogCategory",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Blog.BlogTag",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Blog.BlogPicture",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Notification.Message",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(),
                        Title = c.String(nullable: false, maxLength: 100),
                        Body = c.String(nullable: false, maxLength: 500),
                        IsRead = c.Boolean(nullable: false),
                        IsReplied = c.Boolean(nullable: false),
                        MessageType = c.Byte(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Notification.MessageResponse",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Body = c.String(nullable: false, maxLength: 500),
                        ParentId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Notification.MessageResponse", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Membership.Profile",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        CellPhone = c.String(maxLength: 50),
                        BirthDate = c.DateTime(),
                        AvatarId = c.Guid(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Membership.ProfileAvatar", t => t.AvatarId)
                .Index(t => t.AvatarId);
            
            CreateTable(
                "Membership.ProfileAvatar",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Membership.Role",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 4000),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "Membership.Operation",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Membership.Permision",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Access = c.Boolean(nullable: false),
                        OperationId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Membership.Operation", t => t.OperationId)
                .Index(t => t.OperationId);
            
            CreateTable(
                "Shipping.Courier",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Shipping.DeliveryOption",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Globalization.Language",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CultureCode = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsRightToLeft = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Notification.Newsletter",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 80),
                        NotIncluded = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Notification.Notification",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Body = c.String(maxLength: 500),
                        IsTerminated = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductRating",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Score = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Product.Product", t => t.ProductId)
                .ForeignKey("Membership.User", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Setting.Setting",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Setting.MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 128),
                        ContextKey = c.String(),
                        Model = c.Binary(),
                        ProductVersion = c.String(),
                    })
                .PrimaryKey(t => t.MigrationId);
            
            CreateTable(
                "Document.Guide_Picture",
                c => new
                    {
                        GuideId = c.Guid(nullable: false),
                        PictureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GuideId, t.PictureId })
                .ForeignKey("Document.Guide", t => t.GuideId, cascadeDelete: true)
                .ForeignKey("Document.Picture", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.GuideId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "Document.About_Picture",
                c => new
                    {
                        AboutId = c.Guid(nullable: false),
                        PictureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AboutId, t.PictureId })
                .ForeignKey("Document.About", t => t.AboutId, cascadeDelete: true)
                .ForeignKey("Document.Picture", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.AboutId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "Location.Region_Area",
                c => new
                    {
                        RegionName = c.String(nullable: false, maxLength: 200),
                        AreaName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.RegionName, t.AreaName })
                .ForeignKey("Location.Region", t => t.RegionName, cascadeDelete: true)
                .ForeignKey("Location.Area", t => t.AreaName, cascadeDelete: true)
                .Index(t => t.RegionName)
                .Index(t => t.AreaName);
            
            CreateTable(
                "Location.City_Region",
                c => new
                    {
                        CityName = c.String(nullable: false, maxLength: 100),
                        RegionName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.CityName, t.RegionName })
                .ForeignKey("Location.City", t => t.CityName, cascadeDelete: true)
                .ForeignKey("Location.Region", t => t.RegionName, cascadeDelete: true)
                .Index(t => t.CityName)
                .Index(t => t.RegionName);
            
            CreateTable(
                "Location.State_City",
                c => new
                    {
                        StateName = c.String(nullable: false, maxLength: 100),
                        CityName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.StateName, t.CityName })
                .ForeignKey("Location.State", t => t.StateName, cascadeDelete: true)
                .ForeignKey("Location.City", t => t.CityName, cascadeDelete: true)
                .Index(t => t.StateName)
                .Index(t => t.CityName);
            
            CreateTable(
                "Location.Country_State",
                c => new
                    {
                        CountryName = c.String(nullable: false, maxLength: 100),
                        StateName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.CountryName, t.StateName })
                .ForeignKey("Location.Country", t => t.CountryName, cascadeDelete: true)
                .ForeignKey("Location.State", t => t.StateName, cascadeDelete: true)
                .Index(t => t.CountryName)
                .Index(t => t.StateName);
            
            CreateTable(
                "Membership.User_banner",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        BannerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BannerId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Banner.Banner", t => t.BannerId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BannerId);
            
            CreateTable(
                "Product.ProductAttribute_AttributeOption",
                c => new
                    {
                        AttributeId = c.Guid(nullable: false),
                        OptionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.OptionName })
                .ForeignKey("Product.ProductAttribute", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("Product.ProductAttributeOption", t => t.OptionName, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.OptionName);
            
            CreateTable(
                "Product.ProductCategory_ProductAttribute",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        AttributeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryName, t.AttributeId })
                .ForeignKey("Product.ProductCategory", t => t.CategoryName, cascadeDelete: true)
                .ForeignKey("Product.ProductAttribute", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.CategoryName)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "Product.ProductCategory_ProductBrand",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        BrandName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CategoryName, t.BrandName })
                .ForeignKey("Product.ProductCategory", t => t.CategoryName, cascadeDelete: true)
                .ForeignKey("Product.ProductBrand", t => t.BrandName, cascadeDelete: true)
                .Index(t => t.CategoryName)
                .Index(t => t.BrandName);
            
            CreateTable(
                "Product.ProductTag_ProductSize",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 50),
                        SizeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.TagName, t.SizeName })
                .ForeignKey("Product.ProductTag", t => t.TagName, cascadeDelete: true)
                .ForeignKey("Product.ProductSize", t => t.SizeName, cascadeDelete: true)
                .Index(t => t.TagName)
                .Index(t => t.SizeName);
            
            CreateTable(
                "Product.ProductCategory_ProductTag",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CategoryName, t.TagName })
                .ForeignKey("Product.ProductCategory", t => t.CategoryName, cascadeDelete: true)
                .ForeignKey("Product.ProductTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.CategoryName)
                .Index(t => t.TagName);
            
            CreateTable(
                "Discount.Discount_ProductBrand",
                c => new
                    {
                        DiscountId = c.Guid(nullable: false),
                        BrandName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.BrandName })
                .ForeignKey("Discount.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("Product.ProductBrand", t => t.BrandName, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.BrandName);
            
            CreateTable(
                "Discount.Discount_ProductCategory",
                c => new
                    {
                        DiscountId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.CategoryName })
                .ForeignKey("Discount.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("Product.ProductCategory", t => t.CategoryName, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.CategoryName);
            
            CreateTable(
                "Discount.Discount_Product",
                c => new
                    {
                        DiscountId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.ProductId })
                .ForeignKey("Discount.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Discount.Discount_ProductTag",
                c => new
                    {
                        DiscountId = c.Guid(nullable: false),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.TagName })
                .ForeignKey("Discount.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("Product.ProductTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.TagName);
            
            CreateTable(
                "Document.Document_SocialMedia",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        SocialMediaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentId, t.SocialMediaId })
                .ForeignKey("Document.Document", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("Document.SocialMedia", t => t.SocialMediaId, cascadeDelete: true)
                .Index(t => t.DocumentId)
                .Index(t => t.SocialMediaId);
            
            CreateTable(
                "Membership.Favorite_Product",
                c => new
                    {
                        FavoriteId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FavoriteId, t.ProductId })
                .ForeignKey("Membership.Favorite", t => t.FavoriteId, cascadeDelete: true)
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FavoriteId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Membership.Favorite_Store",
                c => new
                    {
                        FavoriteId = c.Guid(nullable: false),
                        StoreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FavoriteId, t.StoreId })
                .ForeignKey("Membership.Favorite", t => t.FavoriteId, cascadeDelete: true)
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.FavoriteId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "Store.Store_Picture",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        PictureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.PictureId })
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("Store.StorePicture", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "Store.Store_Product",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.ProductId })
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Store.Store_Comment",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        StoreCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreId, t.StoreCommentId })
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("Store.StoreComment", t => t.StoreCommentId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.StoreCommentId);
            
            CreateTable(
                "Discount.Discount_Store",
                c => new
                    {
                        DiscountId = c.Guid(nullable: false),
                        StoreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.StoreId })
                .ForeignKey("Discount.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "Order.Order_OrdetItem",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        OrderItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.OrderItemId })
                .ForeignKey("Order.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("Order.OrderItem", t => t.OrderItemId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.OrderItemId);
            
            CreateTable(
                "Product.Product_ProductAttributeOption",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        OptionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OptionName })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductAttributeOption", t => t.OptionName, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OptionName);
            
            CreateTable(
                "Product.Product_ProductAttribute",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        AttributeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.AttributeId })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductAttribute", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "Product.Product_ProductColor",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ColorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ColorName })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductColor", t => t.ColorName, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ColorName);
            
            CreateTable(
                "Product.Product_ProductComment",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductCommentId })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductComment", t => t.ProductCommentId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductCommentId);
            
            CreateTable(
                "Product.Product_ProductPicture",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductPictureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductPictureId })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductPicture", t => t.ProductPictureId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductPictureId);
            
            CreateTable(
                "Product.Product_ProductSize",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        SizeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SizeName })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductSize", t => t.SizeName, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeName);
            
            CreateTable(
                "Product.Product_ProductTag",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductId, t.TagName })
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Product.ProductTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TagName);
            
            CreateTable(
                "Basket.Basket_BasketItem",
                c => new
                    {
                        BasketId = c.Guid(nullable: false),
                        BasketItemId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.BasketId, t.BasketItemId })
                .ForeignKey("Basket.Basket", t => t.BasketId, cascadeDelete: true)
                .ForeignKey("Basket.BasketItem", t => t.BasketItemId, cascadeDelete: true)
                .Index(t => t.BasketId)
                .Index(t => t.BasketItemId);
            
            CreateTable(
                "Blog.BlogCategory_BlogTag",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CategoryName, t.TagName })
                .ForeignKey("Blog.BlogCategory", t => t.CategoryName, cascadeDelete: true)
                .ForeignKey("Blog.BlogTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.CategoryName)
                .Index(t => t.TagName);
            
            CreateTable(
                "Blog.Blog_BlogComment",
                c => new
                    {
                        BlogPostId = c.Guid(nullable: false),
                        BlogCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPostId, t.BlogCommentId })
                .ForeignKey("Blog.BlogPost", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("Blog.BlogComment", t => t.BlogCommentId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.BlogCommentId);
            
            CreateTable(
                "Blog.Blog_BlogPicture",
                c => new
                    {
                        BlogPostId = c.Guid(nullable: false),
                        BlogPictureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPostId, t.BlogPictureId })
                .ForeignKey("Blog.BlogPost", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("Blog.BlogPicture", t => t.BlogPictureId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.BlogPictureId);
            
            CreateTable(
                "Blog.Blog_BlogTag",
                c => new
                    {
                        BlogPostId = c.Guid(nullable: false),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.BlogPostId, t.TagName })
                .ForeignKey("Blog.BlogPost", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("Blog.BlogTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.TagName);
            
            CreateTable(
                "Membership.User_BlogComment",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        BlogCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BlogCommentId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Blog.BlogComment", t => t.BlogCommentId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BlogCommentId);
            
            CreateTable(
                "Membership.User_Favorite",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        FavoriteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FavoriteId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Membership.Favorite", t => t.FavoriteId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FavoriteId);
            
            CreateTable(
                "Membership.User_Location",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LocationId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Location.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "Notification.Message_Response",
                c => new
                    {
                        MessageId = c.Guid(nullable: false),
                        ResponseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageId, t.ResponseId })
                .ForeignKey("Notification.Message", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("Notification.MessageResponse", t => t.ResponseId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.ResponseId);
            
            CreateTable(
                "Membership.User_Message",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        MessageId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MessageId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Notification.Message", t => t.MessageId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "Membership.User_Payment",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PaymentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PaymentId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Payment.Payment", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "Membership.User_ProductComment",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        ProductCommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProductCommentId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Product.ProductComment", t => t.ProductCommentId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductCommentId);
            
            CreateTable(
                "Membership.User_Product",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProductId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Product.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Membership.Role_Operation",
                c => new
                    {
                        RoleName = c.String(nullable: false, maxLength: 50),
                        OperationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleName, t.OperationId })
                .ForeignKey("Membership.Role", t => t.RoleName, cascadeDelete: true)
                .ForeignKey("Membership.Operation", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.RoleName)
                .Index(t => t.OperationId);
            
            CreateTable(
                "Membership.Role_Permision",
                c => new
                    {
                        RoleName = c.String(nullable: false, maxLength: 50),
                        PermisionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleName, t.PermisionId })
                .ForeignKey("Membership.Role", t => t.RoleName, cascadeDelete: true)
                .ForeignKey("Membership.Permision", t => t.PermisionId, cascadeDelete: true)
                .Index(t => t.RoleName)
                .Index(t => t.PermisionId);
            
            CreateTable(
                "Membership.User_Store",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        StoreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.StoreId })
                .ForeignKey("Membership.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Store.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Product.ProductRating", "UserId", "Membership.User");
            DropForeignKey("Product.ProductRating", "ProductId", "Product.Product");
            DropForeignKey("Membership.User_Store", "StoreId", "Store.Store");
            DropForeignKey("Membership.User_Store", "UserId", "Membership.User");
            DropForeignKey("Membership.User", "RoleName", "Membership.Role");
            DropForeignKey("Membership.Role_Permision", "PermisionId", "Membership.Permision");
            DropForeignKey("Membership.Role_Permision", "RoleName", "Membership.Role");
            DropForeignKey("Membership.Permision", "OperationId", "Membership.Operation");
            DropForeignKey("Membership.Role_Operation", "OperationId", "Membership.Operation");
            DropForeignKey("Membership.Role_Operation", "RoleName", "Membership.Role");
            DropForeignKey("Membership.User", "ProfileId", "Membership.Profile");
            DropForeignKey("Membership.Profile", "AvatarId", "Membership.ProfileAvatar");
            DropForeignKey("Membership.User_Product", "ProductId", "Product.Product");
            DropForeignKey("Membership.User_Product", "UserId", "Membership.User");
            DropForeignKey("Membership.User_ProductComment", "ProductCommentId", "Product.ProductComment");
            DropForeignKey("Membership.User_ProductComment", "UserId", "Membership.User");
            DropForeignKey("Membership.User_Payment", "PaymentId", "Payment.Payment");
            DropForeignKey("Membership.User_Payment", "UserId", "Membership.User");
            DropForeignKey("Membership.User_Message", "MessageId", "Notification.Message");
            DropForeignKey("Membership.User_Message", "UserId", "Membership.User");
            DropForeignKey("Notification.Message_Response", "ResponseId", "Notification.MessageResponse");
            DropForeignKey("Notification.Message_Response", "MessageId", "Notification.Message");
            DropForeignKey("Notification.MessageResponse", "ParentId", "Notification.MessageResponse");
            DropForeignKey("Membership.User_Location", "LocationId", "Location.Location");
            DropForeignKey("Membership.User_Location", "UserId", "Membership.User");
            DropForeignKey("Membership.User_Favorite", "FavoriteId", "Membership.Favorite");
            DropForeignKey("Membership.User_Favorite", "UserId", "Membership.User");
            DropForeignKey("Membership.User_BlogComment", "BlogCommentId", "Blog.BlogComment");
            DropForeignKey("Membership.User_BlogComment", "UserId", "Membership.User");
            DropForeignKey("Blog.Blog_BlogTag", "TagName", "Blog.BlogTag");
            DropForeignKey("Blog.Blog_BlogTag", "BlogPostId", "Blog.BlogPost");
            DropForeignKey("Blog.Blog_BlogPicture", "BlogPictureId", "Blog.BlogPicture");
            DropForeignKey("Blog.Blog_BlogPicture", "BlogPostId", "Blog.BlogPost");
            DropForeignKey("Blog.Blog_BlogComment", "BlogCommentId", "Blog.BlogComment");
            DropForeignKey("Blog.Blog_BlogComment", "BlogPostId", "Blog.BlogPost");
            DropForeignKey("Blog.BlogPost", "Category", "Blog.BlogCategory");
            DropForeignKey("Blog.BlogCategory_BlogTag", "TagName", "Blog.BlogTag");
            DropForeignKey("Blog.BlogCategory_BlogTag", "CategoryName", "Blog.BlogCategory");
            DropForeignKey("Blog.BlogComment", "ParentId", "Blog.BlogComment");
            DropForeignKey("Membership.User", "BasketId", "Basket.Basket");
            DropForeignKey("Basket.Basket_BasketItem", "BasketItemId", "Basket.BasketItem");
            DropForeignKey("Basket.Basket_BasketItem", "BasketId", "Basket.Basket");
            DropForeignKey("Basket.BasketItem", "ProductId", "Product.Product");
            DropForeignKey("Product.Product_ProductTag", "TagName", "Product.ProductTag");
            DropForeignKey("Product.Product_ProductTag", "ProductId", "Product.Product");
            DropForeignKey("Product.Product", "SpecialStateId", "Product.ProductSpecialState");
            DropForeignKey("Product.Product_ProductSize", "SizeName", "Product.ProductSize");
            DropForeignKey("Product.Product_ProductSize", "ProductId", "Product.Product");
            DropForeignKey("Product.Product_ProductPicture", "ProductPictureId", "Product.ProductPicture");
            DropForeignKey("Product.Product_ProductPicture", "ProductId", "Product.Product");
            DropForeignKey("Product.Product_ProductComment", "ProductCommentId", "Product.ProductComment");
            DropForeignKey("Product.Product_ProductComment", "ProductId", "Product.Product");
            DropForeignKey("Product.ProductComment", "ParentId", "Product.ProductComment");
            DropForeignKey("Product.Product_ProductColor", "ColorName", "Product.ProductColor");
            DropForeignKey("Product.Product_ProductColor", "ProductId", "Product.Product");
            DropForeignKey("Product.ProductColor", "IconId", "Product.ProductIcon");
            DropForeignKey("Product.Product", "Category", "Product.ProductCategory");
            DropForeignKey("Product.Product", "Brand", "Product.ProductBrand");
            DropForeignKey("Product.Product_ProductAttribute", "AttributeId", "Product.ProductAttribute");
            DropForeignKey("Product.Product_ProductAttribute", "ProductId", "Product.Product");
            DropForeignKey("Product.Product_ProductAttributeOption", "OptionName", "Product.ProductAttributeOption");
            DropForeignKey("Product.Product_ProductAttributeOption", "ProductId", "Product.Product");
            DropForeignKey("Order.Order", "Product_Id", "Product.Product");
            DropForeignKey("Order.Order", "User_Id", "Membership.User");
            DropForeignKey("Order.Order", "ShippingServiceId", "Shipping.ShippingService");
            DropForeignKey("Order.Order", "PaymentId", "Payment.Payment");
            DropForeignKey("Order.Order", "LocationId", "Location.Location");
            DropForeignKey("Order.Order_OrdetItem", "OrderItemId", "Order.OrderItem");
            DropForeignKey("Order.Order_OrdetItem", "OrderId", "Order.Order");
            DropForeignKey("Discount.Discount_Store", "StoreId", "Store.Store");
            DropForeignKey("Discount.Discount_Store", "DiscountId", "Discount.Discount");
            DropForeignKey("Store.Store_Comment", "StoreCommentId", "Store.StoreComment");
            DropForeignKey("Store.Store_Comment", "StoreId", "Store.Store");
            DropForeignKey("Membership.User", "StoreComment_Id", "Store.StoreComment");
            DropForeignKey("Store.StoreComment", "ParentId", "Store.StoreComment");
            DropForeignKey("Store.Store_Product", "ProductId", "Product.Product");
            DropForeignKey("Store.Store_Product", "StoreId", "Store.Store");
            DropForeignKey("Store.Store_Picture", "PictureId", "Store.StorePicture");
            DropForeignKey("Store.Store_Picture", "StoreId", "Store.Store");
            DropForeignKey("Store.Store", "LocationId", "Location.Location");
            DropForeignKey("Location.Location", "StateName", "Location.State");
            DropForeignKey("Location.Location", "CountryName", "Location.Country");
            DropForeignKey("Location.Location", "AddressId", "Location.Address");
            DropForeignKey("Membership.Favorite_Store", "StoreId", "Store.Store");
            DropForeignKey("Membership.Favorite_Store", "FavoriteId", "Membership.Favorite");
            DropForeignKey("Membership.Favorite_Product", "ProductId", "Product.Product");
            DropForeignKey("Membership.Favorite_Product", "FavoriteId", "Membership.Favorite");
            DropForeignKey("Store.Store", "DocumentId", "Document.Document");
            DropForeignKey("Document.Document_SocialMedia", "SocialMediaId", "Document.SocialMedia");
            DropForeignKey("Document.Document_SocialMedia", "DocumentId", "Document.Document");
            DropForeignKey("Document.SocialMedia", "SocialMediaOptionName", "Document.SocialMediaOption");
            DropForeignKey("Document.Document", "RuleId", "Document.Rule");
            DropForeignKey("Document.Document", "InformationId", "Document.Information");
            DropForeignKey("Document.Document", "GuideId", "Document.Guide");
            DropForeignKey("Document.Document", "AboutId", "Document.About");
            DropForeignKey("Discount.Discount_ProductTag", "TagName", "Product.ProductTag");
            DropForeignKey("Discount.Discount_ProductTag", "DiscountId", "Discount.Discount");
            DropForeignKey("Discount.Discount_Product", "ProductId", "Product.Product");
            DropForeignKey("Discount.Discount_Product", "DiscountId", "Discount.Discount");
            DropForeignKey("Discount.Discount_ProductCategory", "CategoryName", "Product.ProductCategory");
            DropForeignKey("Discount.Discount_ProductCategory", "DiscountId", "Discount.Discount");
            DropForeignKey("Discount.Discount_ProductBrand", "BrandName", "Product.ProductBrand");
            DropForeignKey("Discount.Discount_ProductBrand", "DiscountId", "Discount.Discount");
            DropForeignKey("Product.ProductCategory_ProductTag", "TagName", "Product.ProductTag");
            DropForeignKey("Product.ProductCategory_ProductTag", "CategoryName", "Product.ProductCategory");
            DropForeignKey("Product.ProductTag_ProductSize", "SizeName", "Product.ProductSize");
            DropForeignKey("Product.ProductTag_ProductSize", "TagName", "Product.ProductTag");
            DropForeignKey("Product.ProductTag", "IconId", "Product.ProductIcon");
            DropForeignKey("Product.ProductCategory", "ParentCategory", "Product.ProductCategory");
            DropForeignKey("Product.ProductCategory_ProductBrand", "BrandName", "Product.ProductBrand");
            DropForeignKey("Product.ProductCategory_ProductBrand", "CategoryName", "Product.ProductCategory");
            DropForeignKey("Product.ProductCategory_ProductAttribute", "AttributeId", "Product.ProductAttribute");
            DropForeignKey("Product.ProductCategory_ProductAttribute", "CategoryName", "Product.ProductCategory");
            DropForeignKey("Product.ProductAttribute_AttributeOption", "OptionName", "Product.ProductAttributeOption");
            DropForeignKey("Product.ProductAttribute_AttributeOption", "AttributeId", "Product.ProductAttribute");
            DropForeignKey("Product.ProductCategory", "IconId", "Product.ProductIcon");
            DropForeignKey("Product.ProductBrand", "IconId", "Product.ProductIcon");
            DropForeignKey("Membership.User_banner", "BannerId", "Banner.Banner");
            DropForeignKey("Membership.User_banner", "UserId", "Membership.User");
            DropForeignKey("Banner.Banner", "PictureId", "Banner.BannerPicture");
            DropForeignKey("Location.Country_State", "StateName", "Location.State");
            DropForeignKey("Location.Country_State", "CountryName", "Location.Country");
            DropForeignKey("Location.State_City", "CityName", "Location.City");
            DropForeignKey("Location.State_City", "StateName", "Location.State");
            DropForeignKey("Location.City_Region", "RegionName", "Location.Region");
            DropForeignKey("Location.City_Region", "CityName", "Location.City");
            DropForeignKey("Location.Region_Area", "AreaName", "Location.Area");
            DropForeignKey("Location.Region_Area", "RegionName", "Location.Region");
            DropForeignKey("Document.About_Picture", "PictureId", "Document.Picture");
            DropForeignKey("Document.About_Picture", "AboutId", "Document.About");
            DropForeignKey("Document.Guide_Picture", "PictureId", "Document.Picture");
            DropForeignKey("Document.Guide_Picture", "GuideId", "Document.Guide");
            DropIndex("Product.ProductRating", new[] { "UserId" });
            DropIndex("Product.ProductRating", new[] { "ProductId" });
            DropIndex("Membership.User_Store", new[] { "StoreId" });
            DropIndex("Membership.User_Store", new[] { "UserId" });
            DropIndex("Membership.User", new[] { "RoleName" });
            DropIndex("Membership.Role_Permision", new[] { "PermisionId" });
            DropIndex("Membership.Role_Permision", new[] { "RoleName" });
            DropIndex("Membership.Permision", new[] { "OperationId" });
            DropIndex("Membership.Role_Operation", new[] { "OperationId" });
            DropIndex("Membership.Role_Operation", new[] { "RoleName" });
            DropIndex("Membership.User", new[] { "ProfileId" });
            DropIndex("Membership.Profile", new[] { "AvatarId" });
            DropIndex("Membership.User_Product", new[] { "ProductId" });
            DropIndex("Membership.User_Product", new[] { "UserId" });
            DropIndex("Membership.User_ProductComment", new[] { "ProductCommentId" });
            DropIndex("Membership.User_ProductComment", new[] { "UserId" });
            DropIndex("Membership.User_Payment", new[] { "PaymentId" });
            DropIndex("Membership.User_Payment", new[] { "UserId" });
            DropIndex("Membership.User_Message", new[] { "MessageId" });
            DropIndex("Membership.User_Message", new[] { "UserId" });
            DropIndex("Notification.Message_Response", new[] { "ResponseId" });
            DropIndex("Notification.Message_Response", new[] { "MessageId" });
            DropIndex("Notification.MessageResponse", new[] { "ParentId" });
            DropIndex("Membership.User_Location", new[] { "LocationId" });
            DropIndex("Membership.User_Location", new[] { "UserId" });
            DropIndex("Membership.User_Favorite", new[] { "FavoriteId" });
            DropIndex("Membership.User_Favorite", new[] { "UserId" });
            DropIndex("Membership.User_BlogComment", new[] { "BlogCommentId" });
            DropIndex("Membership.User_BlogComment", new[] { "UserId" });
            DropIndex("Blog.Blog_BlogTag", new[] { "TagName" });
            DropIndex("Blog.Blog_BlogTag", new[] { "BlogPostId" });
            DropIndex("Blog.Blog_BlogPicture", new[] { "BlogPictureId" });
            DropIndex("Blog.Blog_BlogPicture", new[] { "BlogPostId" });
            DropIndex("Blog.Blog_BlogComment", new[] { "BlogCommentId" });
            DropIndex("Blog.Blog_BlogComment", new[] { "BlogPostId" });
            DropIndex("Blog.BlogPost", new[] { "Category" });
            DropIndex("Blog.BlogCategory_BlogTag", new[] { "TagName" });
            DropIndex("Blog.BlogCategory_BlogTag", new[] { "CategoryName" });
            DropIndex("Blog.BlogComment", new[] { "ParentId" });
            DropIndex("Membership.User", new[] { "BasketId" });
            DropIndex("Basket.Basket_BasketItem", new[] { "BasketItemId" });
            DropIndex("Basket.Basket_BasketItem", new[] { "BasketId" });
            DropIndex("Basket.BasketItem", new[] { "ProductId" });
            DropIndex("Product.Product_ProductTag", new[] { "TagName" });
            DropIndex("Product.Product_ProductTag", new[] { "ProductId" });
            DropIndex("Product.Product", new[] { "SpecialStateId" });
            DropIndex("Product.Product_ProductSize", new[] { "SizeName" });
            DropIndex("Product.Product_ProductSize", new[] { "ProductId" });
            DropIndex("Product.Product_ProductPicture", new[] { "ProductPictureId" });
            DropIndex("Product.Product_ProductPicture", new[] { "ProductId" });
            DropIndex("Product.Product_ProductComment", new[] { "ProductCommentId" });
            DropIndex("Product.Product_ProductComment", new[] { "ProductId" });
            DropIndex("Product.ProductComment", new[] { "ParentId" });
            DropIndex("Product.Product_ProductColor", new[] { "ColorName" });
            DropIndex("Product.Product_ProductColor", new[] { "ProductId" });
            DropIndex("Product.ProductColor", new[] { "IconId" });
            DropIndex("Product.Product", new[] { "Category" });
            DropIndex("Product.Product", new[] { "Brand" });
            DropIndex("Product.Product_ProductAttribute", new[] { "AttributeId" });
            DropIndex("Product.Product_ProductAttribute", new[] { "ProductId" });
            DropIndex("Product.Product_ProductAttributeOption", new[] { "OptionName" });
            DropIndex("Product.Product_ProductAttributeOption", new[] { "ProductId" });
            DropIndex("Order.Order", new[] { "Product_Id" });
            DropIndex("Order.Order", new[] { "User_Id" });
            DropIndex("Order.Order", new[] { "ShippingServiceId" });
            DropIndex("Order.Order", new[] { "PaymentId" });
            DropIndex("Order.Order", new[] { "LocationId" });
            DropIndex("Order.Order_OrdetItem", new[] { "OrderItemId" });
            DropIndex("Order.Order_OrdetItem", new[] { "OrderId" });
            DropIndex("Discount.Discount_Store", new[] { "StoreId" });
            DropIndex("Discount.Discount_Store", new[] { "DiscountId" });
            DropIndex("Store.Store_Comment", new[] { "StoreCommentId" });
            DropIndex("Store.Store_Comment", new[] { "StoreId" });
            DropIndex("Membership.User", new[] { "StoreComment_Id" });
            DropIndex("Store.StoreComment", new[] { "ParentId" });
            DropIndex("Store.Store_Product", new[] { "ProductId" });
            DropIndex("Store.Store_Product", new[] { "StoreId" });
            DropIndex("Store.Store_Picture", new[] { "PictureId" });
            DropIndex("Store.Store_Picture", new[] { "StoreId" });
            DropIndex("Store.Store", new[] { "LocationId" });
            DropIndex("Location.Location", new[] { "StateName" });
            DropIndex("Location.Location", new[] { "CountryName" });
            DropIndex("Location.Location", new[] { "AddressId" });
            DropIndex("Membership.Favorite_Store", new[] { "StoreId" });
            DropIndex("Membership.Favorite_Store", new[] { "FavoriteId" });
            DropIndex("Membership.Favorite_Product", new[] { "ProductId" });
            DropIndex("Membership.Favorite_Product", new[] { "FavoriteId" });
            DropIndex("Store.Store", new[] { "DocumentId" });
            DropIndex("Document.Document_SocialMedia", new[] { "SocialMediaId" });
            DropIndex("Document.Document_SocialMedia", new[] { "DocumentId" });
            DropIndex("Document.SocialMedia", new[] { "SocialMediaOptionName" });
            DropIndex("Document.Document", new[] { "RuleId" });
            DropIndex("Document.Document", new[] { "InformationId" });
            DropIndex("Document.Document", new[] { "GuideId" });
            DropIndex("Document.Document", new[] { "AboutId" });
            DropIndex("Discount.Discount_ProductTag", new[] { "TagName" });
            DropIndex("Discount.Discount_ProductTag", new[] { "DiscountId" });
            DropIndex("Discount.Discount_Product", new[] { "ProductId" });
            DropIndex("Discount.Discount_Product", new[] { "DiscountId" });
            DropIndex("Discount.Discount_ProductCategory", new[] { "CategoryName" });
            DropIndex("Discount.Discount_ProductCategory", new[] { "DiscountId" });
            DropIndex("Discount.Discount_ProductBrand", new[] { "BrandName" });
            DropIndex("Discount.Discount_ProductBrand", new[] { "DiscountId" });
            DropIndex("Product.ProductCategory_ProductTag", new[] { "TagName" });
            DropIndex("Product.ProductCategory_ProductTag", new[] { "CategoryName" });
            DropIndex("Product.ProductTag_ProductSize", new[] { "SizeName" });
            DropIndex("Product.ProductTag_ProductSize", new[] { "TagName" });
            DropIndex("Product.ProductTag", new[] { "IconId" });
            DropIndex("Product.ProductCategory", new[] { "ParentCategory" });
            DropIndex("Product.ProductCategory_ProductBrand", new[] { "BrandName" });
            DropIndex("Product.ProductCategory_ProductBrand", new[] { "CategoryName" });
            DropIndex("Product.ProductCategory_ProductAttribute", new[] { "AttributeId" });
            DropIndex("Product.ProductCategory_ProductAttribute", new[] { "CategoryName" });
            DropIndex("Product.ProductAttribute_AttributeOption", new[] { "OptionName" });
            DropIndex("Product.ProductAttribute_AttributeOption", new[] { "AttributeId" });
            DropIndex("Product.ProductCategory", new[] { "IconId" });
            DropIndex("Product.ProductBrand", new[] { "IconId" });
            DropIndex("Membership.User_banner", new[] { "BannerId" });
            DropIndex("Membership.User_banner", new[] { "UserId" });
            DropIndex("Banner.Banner", new[] { "PictureId" });
            DropIndex("Location.Country_State", new[] { "StateName" });
            DropIndex("Location.Country_State", new[] { "CountryName" });
            DropIndex("Location.State_City", new[] { "CityName" });
            DropIndex("Location.State_City", new[] { "StateName" });
            DropIndex("Location.City_Region", new[] { "RegionName" });
            DropIndex("Location.City_Region", new[] { "CityName" });
            DropIndex("Location.Region_Area", new[] { "AreaName" });
            DropIndex("Location.Region_Area", new[] { "RegionName" });
            DropIndex("Document.About_Picture", new[] { "PictureId" });
            DropIndex("Document.About_Picture", new[] { "AboutId" });
            DropIndex("Document.Guide_Picture", new[] { "PictureId" });
            DropIndex("Document.Guide_Picture", new[] { "GuideId" });
            DropTable("Membership.User_Store");
            DropTable("Membership.Role_Permision");
            DropTable("Membership.Role_Operation");
            DropTable("Membership.User_Product");
            DropTable("Membership.User_ProductComment");
            DropTable("Membership.User_Payment");
            DropTable("Membership.User_Message");
            DropTable("Notification.Message_Response");
            DropTable("Membership.User_Location");
            DropTable("Membership.User_Favorite");
            DropTable("Membership.User_BlogComment");
            DropTable("Blog.Blog_BlogTag");
            DropTable("Blog.Blog_BlogPicture");
            DropTable("Blog.Blog_BlogComment");
            DropTable("Blog.BlogCategory_BlogTag");
            DropTable("Basket.Basket_BasketItem");
            DropTable("Product.Product_ProductTag");
            DropTable("Product.Product_ProductSize");
            DropTable("Product.Product_ProductPicture");
            DropTable("Product.Product_ProductComment");
            DropTable("Product.Product_ProductColor");
            DropTable("Product.Product_ProductAttribute");
            DropTable("Product.Product_ProductAttributeOption");
            DropTable("Order.Order_OrdetItem");
            DropTable("Discount.Discount_Store");
            DropTable("Store.Store_Comment");
            DropTable("Store.Store_Product");
            DropTable("Store.Store_Picture");
            DropTable("Membership.Favorite_Store");
            DropTable("Membership.Favorite_Product");
            DropTable("Document.Document_SocialMedia");
            DropTable("Discount.Discount_ProductTag");
            DropTable("Discount.Discount_Product");
            DropTable("Discount.Discount_ProductCategory");
            DropTable("Discount.Discount_ProductBrand");
            DropTable("Product.ProductCategory_ProductTag");
            DropTable("Product.ProductTag_ProductSize");
            DropTable("Product.ProductCategory_ProductBrand");
            DropTable("Product.ProductCategory_ProductAttribute");
            DropTable("Product.ProductAttribute_AttributeOption");
            DropTable("Membership.User_banner");
            DropTable("Location.Country_State");
            DropTable("Location.State_City");
            DropTable("Location.City_Region");
            DropTable("Location.Region_Area");
            DropTable("Document.About_Picture");
            DropTable("Document.Guide_Picture");
            DropTable("Setting.MigrationHistory");
            DropTable("Setting.Setting");
            DropTable("Product.ProductRating");
            DropTable("Notification.Notification");
            DropTable("Notification.Newsletter");
            DropTable("Globalization.Language");
            DropTable("Shipping.DeliveryOption");
            DropTable("Shipping.Courier");
            DropTable("Membership.Permision");
            DropTable("Membership.Operation");
            DropTable("Membership.Role");
            DropTable("Membership.ProfileAvatar");
            DropTable("Membership.Profile");
            DropTable("Notification.MessageResponse");
            DropTable("Notification.Message");
            DropTable("Blog.BlogPicture");
            DropTable("Blog.BlogTag");
            DropTable("Blog.BlogCategory");
            DropTable("Blog.BlogPost");
            DropTable("Blog.BlogComment");
            DropTable("Product.ProductSpecialState");
            DropTable("Product.ProductPicture");
            DropTable("Product.ProductComment");
            DropTable("Product.ProductColor");
            DropTable("Shipping.ShippingService");
            DropTable("Payment.Payment");
            DropTable("Order.OrderItem");
            DropTable("Order.Order");
            DropTable("Store.StoreComment");
            DropTable("Store.StorePicture");
            DropTable("Location.Location");
            DropTable("Membership.Favorite");
            DropTable("Document.SocialMediaOption");
            DropTable("Document.SocialMedia");
            DropTable("Document.Rule");
            DropTable("Document.Information");
            DropTable("Document.Document");
            DropTable("Store.Store");
            DropTable("Product.ProductSize");
            DropTable("Product.ProductTag");
            DropTable("Product.ProductAttributeOption");
            DropTable("Product.ProductAttribute");
            DropTable("Product.ProductCategory");
            DropTable("Product.ProductIcon");
            DropTable("Product.ProductBrand");
            DropTable("Discount.Discount");
            DropTable("Product.Product");
            DropTable("Basket.BasketItem");
            DropTable("Basket.Basket");
            DropTable("Membership.User");
            DropTable("Banner.Banner");
            DropTable("Banner.BannerPicture");
            DropTable("Location.Country");
            DropTable("Location.State");
            DropTable("Location.City");
            DropTable("Location.Region");
            DropTable("Location.Area");
            DropTable("Location.Address");
            DropTable("Document.Guide");
            DropTable("Document.Picture");
            DropTable("Document.About");
        }
    }
}
