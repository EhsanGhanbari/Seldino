using System;
using System.Data.Entity;
using Seldino.Domain.BannerAggregation;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Domain.BlogAggregation;
using Seldino.Domain.BlogAggregation.BlogComments;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.DocumentAggregation;
using Seldino.Domain.GiftDeskAggregation;
using Seldino.Domain.GlobalizationAggregation;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.NotificationAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.ProductAggregation.ProductRatings;
using Seldino.Domain.SettingAggregation;
using Seldino.Domain.ShippingAggregation;
using Seldino.Domain.StoreAggregation;
using Seldino.Domain.StoreAggregation.StoreComments;
using Seldino.Infrastructure.Helpers;
using Seldino.Repository.Configurations;
using Seldino.Repository.Migrations;

namespace Seldino.Repository.DataContexts
{
    internal class ReadOnlyDataContext : DbContext
    {
        public ReadOnlyDataContext() : base("Seldino")
        {
        }

        #region Banner
        public DbSet<Banner> Banners { get; set; }

        public DbSet<BannerPicture> BannerPictures { get; set; }
        #endregion

        #region Basket
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UnauthorizedBasket> UnauthorizedBaskets { get; set; }
        #endregion

        #region Blog
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<BlogPicture> BlogPictures { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        #endregion

        #region Discount
        public DbSet<Discount> Discounts { get; set; }
        #endregion

        #region Document
        public DbSet<About> Abouts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentPicture> DocumentPictures { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialMediaOption> SocialMediaOptions { get; set; }
        #endregion

        #region GiftDesk
        public DbSet<GiftDesk> GiftDesks { get; set; }
        #endregion

        #region Globalization
        public DbSet<Language> Languages { get; set; }
        #endregion

        #region Location
        public DbSet<Location> Locations { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Address> Addresses { get; set; }
        #endregion

        #region Membership
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Permision> Permisions { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ProfileAvatar> ProfileIcons { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        #endregion

        #region Notification
        public DbSet<Message> Messages { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<MessageResponse> MessageResponses { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }
        #endregion

        #region Order
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        #endregion

        #region Payment
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductAttributeOption> ProductAttributeOptions { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ProductComment> ProductComments { get; set; }

        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<ProductRating> ProductRatings { get; set; }

        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<ProductSpecialState> ProductSpecialStates { get; set; }

        public DbSet<ProductIcon> ProductIcons { get; set; }
        #endregion

        #region Setting
        public DbSet<Setting> Settings { get; set; }

        public DbSet<BannerSetting> BannerSettings { get; set; }

        public DbSet<BasicSetting> BasicSettings { get; set; }

        public DbSet<BasketSetting> BasketSettings { get; set; }

        public DbSet<BlogSetting> BlogSettings { get; set; }

        public DbSet<DiscountSetting> DiscountSettings { get; set; }

        public DbSet<DocumentSetting> DocumentSettings { get; set; }

        public DbSet<OrderSetting> OrderSettings { get; set; }

        public DbSet<ProductSetting> ProductSettings { get; set; }

        public DbSet<StoreSetting> StoreSettings { get; set; }

        public DbSet<SeoSetting> SeoSettings { get; set; }

        #endregion

        #region Shipping
        public DbSet<DeliveryOption> DeliveryOptions { get; set; }

        public DbSet<ShippingService> ShippingServices { get; set; }

        public DbSet<Courier> Couriers { get; set; }
        #endregion

        #region Store
        public DbSet<Store> Stores { get; set; }

        public DbSet<StorePicture> StorePictures { get; set; }

        public DbSet<StoreComment> StoreComments { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Seldino");

            #region Banner
            modelBuilder.Configurations.Add(new BannerConfiguration());
            modelBuilder.Configurations.Add(new BannerPictureConfiguration());
            #endregion

            #region Basket
            modelBuilder.Configurations.Add(new BasketConfiguration());
            modelBuilder.Configurations.Add(new UnauthorizedBasketConfiguration());
            modelBuilder.Configurations.Add(new BasketItemConfiguration());
            modelBuilder.Configurations.Add(new UnauthorizedBasketItemConfigucation());
            #endregion

            #region Blog
            modelBuilder.Configurations.Add(new BlogPostConfiguration());
            modelBuilder.Configurations.Add(new BlogCategoryConfiguration());
            modelBuilder.Configurations.Add(new BlogTagConfiguration());
            modelBuilder.Configurations.Add(new BlogPictureConfiguration());
            modelBuilder.Configurations.Add(new BlogCommentConfiguration());
            #endregion

            #region Discount
            modelBuilder.Configurations.Add(new DiscountConfiguration());
            #endregion

            #region Document
            modelBuilder.Configurations.Add(new AboutConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());
            modelBuilder.Configurations.Add(new DocumentPictureConfiguration());
            modelBuilder.Configurations.Add(new GuideConfiguration());
            modelBuilder.Configurations.Add(new InformationConfiguration());
            modelBuilder.Configurations.Add(new RuleConfiguration());
            modelBuilder.Configurations.Add(new SocialMediaConfiguration());
            modelBuilder.Configurations.Add(new SocialMediaOptionConfiguration());
            #endregion

            #region GiftDesk

            modelBuilder.Configurations.Add(new GiftDeskConfiguration());

            #endregion

            #region Language
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            #endregion

            #region Location
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new RegionConfiguration());
            modelBuilder.Configurations.Add(new AreaConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            #endregion

            #region Membership
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OperationConfiguration());
            modelBuilder.Configurations.Add(new PermisionConfiguration());
            modelBuilder.Configurations.Add(new ProfileAvatarConfiguration());
            modelBuilder.Configurations.Add(new FavoriteConfiguration());

            #endregion

            #region Notification
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new MessageResponseConfiguration());
            modelBuilder.Configurations.Add(new NewsletterConfiguration());
            #endregion

            #region Order
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());
            #endregion

            #region Payment
            modelBuilder.Configurations.Add(new PaymentConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            #endregion

            #region Product
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductAttributeConfiguration());
            modelBuilder.Configurations.Add(new ProductAttributeOptionConfiguration());
            modelBuilder.Configurations.Add(new ProductBrandConficuration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductColorConfiguration());
            modelBuilder.Configurations.Add(new ProductCommentConfiguration());
            modelBuilder.Configurations.Add(new ProductPictureConfiguration());
            modelBuilder.Configurations.Add(new ProductTagConfiguration());
            modelBuilder.Configurations.Add(new ProductRatingConfiguration());
            modelBuilder.Configurations.Add(new ProductSizeConfiguration());
            modelBuilder.Configurations.Add(new ProductSpecialStateConfiguration());
            modelBuilder.Configurations.Add(new ProductIconConfiguration());
            #endregion

            #region Setting
            modelBuilder.Configurations.Add(new SettingConfiguration());
            modelBuilder.Configurations.Add(new BannerSettingConfiguration());
            modelBuilder.Configurations.Add(new BasicSettingConfiguration());
            modelBuilder.Configurations.Add(new BasketSettingConfiguration());
            modelBuilder.Configurations.Add(new BlogSettingConfiguration());
            modelBuilder.Configurations.Add(new DiscountSettingConfiguration());
            modelBuilder.Configurations.Add(new DocumentSettingConfiguration());
            modelBuilder.Configurations.Add(new OrderSettingConfiguration());
            modelBuilder.Configurations.Add(new ProductSettingConfiguration());
            modelBuilder.Configurations.Add(new StoreSettingConfiguration());
            modelBuilder.Configurations.Add(new SeoSettingConfiguration());
            #endregion

            #region Shipping    
            modelBuilder.Configurations.Add(new DeliveryOptionConfiguration());
            modelBuilder.Configurations.Add(new ShippingServiceConfiguration());
            modelBuilder.Configurations.Add(new CourierConfiguration());
            #endregion

            #region Store
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new StorePictureConfiguration());
            modelBuilder.Configurations.Add(new StoreCommentConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
