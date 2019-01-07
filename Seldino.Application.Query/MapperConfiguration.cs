using AutoMapper;
using Seldino.Application.Query.BannerService;
using Seldino.Application.Query.BasketService;
using Seldino.Application.Query.BlogService;
using Seldino.Application.Query.DiscountService;
using Seldino.Application.Query.DocumentService;
using Seldino.Application.Query.LocationService;
using Seldino.Application.Query.MembershipService;
using Seldino.Application.Query.NotificationService;
using Seldino.Application.Query.OrderService;
using Seldino.Application.Query.PaymentService;
using Seldino.Application.Query.ProductService;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.BannerAggregation;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Domain.BlogAggregation;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.DocumentAggregation;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.NotificationAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.QueryModels;
using Seldino.Domain.StoreAggregation;
using Seldino.Domain.StoreAggregation.StoreComments;
using Profile = AutoMapper.Profile;

namespace Seldino.Application.Query
{
    #region Configuration
    public class MapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<QueryMapperProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
    #endregion

    #region Profile
    internal sealed class QueryMapperProfile : Profile
    {
        #region Configuration

        public override string ProfileName => "QueryMapperProfile";

        protected override void Configure()
        {
            ConfigurBannerMapper();
            ConfigureBasketMapper();
            ConfigureBlogMapper();
            ConfigureDiscountMapper();
            ConfigurDocumentMapper();
            ConfigureLocationMapper();
            ConfigureMembershipMapper();
            ConfigureNotificationMapper();
            ConfigureOrderMapper();
            ConfigurePaymentMapper();
            ConfigureProductMapper();
            ConfigureStoreMapper();
        }

        #endregion

        #region Banner

        private static void ConfigurBannerMapper()
        {
            ConfigureBanner();
            ConfigurBannerIncludePagedResult();
            ConfigureBannerPicture();
        }

        private static void ConfigureBanner()
        {
            Mapper.CreateMap<Banner, BannerDto>()
                 .ForMember(des => des.BannerId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigurBannerIncludePagedResult()
        {
            Mapper.CreateMap<Banner, BannerDto>().IncludePagedResultMapping()
              .ForMember(des => des.BannerId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureBannerPicture()
        {
            Mapper.CreateMap<BannerPicture, BannerPictureDto>()
                .ForMember(src => src.PictureId, src => src.MapFrom(s => s.Id));
        }

        #endregion

        #region Basket

        private static void ConfigureBasketMapper()
        {
            ConfigureBasket();
            ConfigureBasketItem();
            ConfigureQuantity();
        }

        private static void ConfigureBasket()
        {
            Mapper.CreateMap<Basket, BasketDto>();
            Mapper.CreateMap<UnauthorizedBasket, BasketDto>();
        }

        private static void ConfigureBasketItem()
        {
            Mapper.CreateMap<BasketItem, BasketItemDto>();
            Mapper.CreateMap<UnauthorizedBasketItem, BasketItemDto>();
        }

        private static void ConfigureQuantity()
        {
            Mapper.CreateMap<Quantity, QuantityDto>();
        }

        #endregion

        #region Blog

        private static void ConfigureBlogMapper()
        {
            ConfigureBlogPostMapper();
            ConfigureBlogPostIncludePagedResult();
            ConfigureBlogTagMapper();
            ConfigureBlogCategoryMapper();
            ConfigureBlogPictureMapper();
        }

        private static void ConfigureBlogPostMapper()
        {
            Mapper.CreateMap<BlogPost, BlogPostDto>()
                .ForMember(des => des.BlogPostId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureBlogPostIncludePagedResult()
        {
            Mapper.CreateMap<BlogPost, BlogPostDto>().IncludePagedResultMapping()
              .ForMember(des => des.BlogPostId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureBlogTagMapper()
        {
            Mapper.CreateMap<BlogTag, BlogTagDto>()
                .ForSourceMember(src => src.BlogPosts, des => des.Ignore())
                .ForSourceMember(src => src.BlogCategories, des => des.Ignore());
        }

        private static void ConfigureBlogCategoryMapper()
        {
            Mapper.CreateMap<BlogCategory, BlogCategoryDto>()
                  .ForSourceMember(src => src.BlogTags, des => des.Ignore());
        }

        private static void ConfigureBlogPictureMapper()
        {
            Mapper.CreateMap<BlogPicture, BlogPictureDto>()
                .ForMember(src => src.PictureId, src => src.MapFrom(s => s.Id))
                .ForSourceMember(src => src.BlogPosts, des => des.Ignore());
        }

        #endregion

        #region Discount

        private static void ConfigureDiscountMapper()
        {
            Mapper.CreateMap<Discount, DiscountDto>()
                .ForMember(des => des.DiscountId, src => src.MapFrom(s => s.Id))
                .ForSourceMember(des => des.Products, des => des.Ignore())
                .ForSourceMember(src => src.Stores, des => des.Ignore());

            Mapper.CreateMap<Discount, DiscountDto>()
              .ForMember(des => des.DiscountId, src => src.MapFrom(s => s.Id))
              .ForSourceMember(des => des.Products, des => des.Ignore())
              .ForSourceMember(src => src.Stores, des => des.Ignore()).IncludePagedResultMapping();
        }

        #endregion

        #region Document

        private static void ConfigurDocumentMapper()
        {
            ConfigureDocument();
            ConfigureDocumentRule();
            ConfigureDocumentAbout();
            ConfigureDocumentPicture();
            ConfigureDocumentSocialMedia();
            ConfigureDocumentSocialMediaOption();
            ConfigureDocumentInforamtion();
            ConfigureDocumentGuide();
        }

        private static void ConfigureDocument()
        {
            Mapper.CreateMap<Document, DocumentDto>()
                .ForMember(src => src.DocumentId, des => des.MapFrom(d => d.Id));
        }

        private static void ConfigureDocumentRule()
        {
            Mapper.CreateMap<Rule, RuleDto>();
        }

        private static void ConfigureDocumentAbout()
        {
            Mapper.CreateMap<About, AboutDto>();
        }

        private static void ConfigureDocumentPicture()
        {
            Mapper.CreateMap<DocumentPicture, DocumentPictureDto>()
                .ForMember(src => src.PictureId, src => src.MapFrom(s => s.Id))
                .ForSourceMember(src => src.Abouts, des => des.Ignore())
                .ForSourceMember(src => src.Guides, des => des.Ignore());
        }

        private static void ConfigureDocumentSocialMedia()
        {
            Mapper.CreateMap<SocialMedia, SocialMediaDto>()
                .ForSourceMember(src => src.Documents, des => des.Ignore());
        }

        private static void ConfigureDocumentSocialMediaOption()
        {
            Mapper.CreateMap<SocialMediaOption, SocialMediaOptionDto>();
        }

        private static void ConfigureDocumentInforamtion()
        {
            Mapper.CreateMap<Information, InformationDto>();
        }

        private static void ConfigureDocumentGuide()
        {
            Mapper.CreateMap<Guide, GuideDto>();
        }

        #endregion

        #region Location
        private static void ConfigureLocationMapper()
        {
            ConfigureLocation();
            ConfigurCountry();
            ConfigureState();
            ConfgureAddress();
        }

        private static void ConfigureLocation()
        {
            Mapper.CreateMap<Location, LocationDto>();
        }

        private static void ConfigurCountry()
        {
            Mapper.CreateMap<Country, CountryDto>();
        }

        private static void ConfigureState()
        {
            Mapper.CreateMap<State, StateDto>();
        }

        private static void ConfgureAddress()
        {
            Mapper.CreateMap<Address, AddressDto>();
        }

        #endregion

        #region Membership

        private static void ConfigureMembershipMapper()
        {
            ConfigureUser();
            CongfigureUserIncludePagedResult();
            ConfigureProfile();
            ConfigureRole();
            ConfigureProfileAvatar();
            ConfigureFavorite();
        }

        private static void ConfigureUser()
        {
            Mapper.CreateMap<User, UserDto>()
                .ForMember(src => src.UserId, src => src.MapFrom(s => s.Id))
                .ForSourceMember(src => src.Stores, des => des.Ignore())
                .ForSourceMember(src => src.Messages, des => des.Ignore())
                .ForSourceMember(src => src.Orders, des => des.Ignore())
                .ForSourceMember(src => src.Payments, des => des.Ignore());
        }

        private static void CongfigureUserIncludePagedResult()
        {
            Mapper.CreateMap<User, UserDto>().IncludePagedResultMapping()
             .ForMember(src => src.UserId, src => src.MapFrom(s => s.Id))
             .ForSourceMember(src => src.Stores, des => des.Ignore())
             .ForSourceMember(src => src.Messages, des => des.Ignore())
             .ForSourceMember(src => src.Orders, des => des.Ignore())
             .ForSourceMember(src => src.Payments, des => des.Ignore());
        }

        private static void ConfigureProfile()
        {
            Mapper.CreateMap<Domain.MembershipAggregation.Profile, ProfileDto>()
                .ForMember(src => src.UserId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureRole()
        {
            Mapper.CreateMap<Role, RoleDto>();
        }

        private static void ConfigureProfileAvatar()
        {
            Mapper.CreateMap<ProfileAvatar, ProfileAvatarDto>()
                 .ForMember(src => src.AvatarId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureFavorite()
        {
            Mapper.CreateMap<Favorite, FavoriteDto>()
                .ForMember(src => src.Number, des => des.Ignore())
                .ForMember(src => src.Product, des => des.Ignore())
                .ForMember(src => src.Store, des => des.Ignore());
        }

        #endregion

        #region Notification

        private static void ConfigureNotificationMapper()
        {
            ConfigureNotification();
            ConfigureMessage();
            ConfigureMessageIncludePagedResult();
            ConfigureNewsletter();
        }

        private static void ConfigureNotification()
        {
            Mapper.CreateMap<Notification, NotificationDto>()
                   .ForMember(src => src.NotificationId, src => src.MapFrom(s => s.Id)).IncludePagedResultMapping();
        }

        private static void ConfigureMessage()
        {
            Mapper.CreateMap<Message, MessageDto>()
                .ForMember(src => src.MessageId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureMessageIncludePagedResult()
        {
            Mapper.CreateMap<Message, MessageDto>()
               .ForMember(src => src.MessageId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureNewsletter()
        {
            Mapper.CreateMap<Newsletter, NewsletterDto>();
        }

        #endregion

        #region Order

        private static void ConfigureOrderMapper()
        {
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderItem, OrderItemDto>();
            Mapper.CreateMap<OrdersCountQueryModel, OrdersCountDto>();
        }

        #endregion

        #region Payment

        private static void ConfigurePaymentMapper()
        {
            Mapper.CreateMap<Payment, PaymentDto>()
                .ForSourceMember(src => src.Users, des => des.Ignore())
                .ForMember(src => src.PaymentId, src => src.MapFrom(s => s.Id));

            Mapper.CreateMap<Invoice, InvoiceDto>();
        }

        #endregion

        #region Product

        private static void ConfigureProductMapper()
        {
            ConfigureProduct();
            ConfigureProductIncludePagedResult();
            ConfigureProduct();
            ConfigureProductBrand();
            ConfigureProductCategory();
            ConfigureProductTag();
            ConfigureProductPicture();
            ConfigureProductColor();
            ConfigureProductSize();
            ConfigureProductAttribute();
            ConfigureProductAttributeOption();
            ConfigureProductIcon();
            ConfigureProductComment();
            ConfigureSpecialState();
        }

        private static void ConfigureProduct()
        {
            Mapper.CreateMap<Product, ProductDto>()
                .ForMember(src => src.ProductName, des => des.MapFrom(d => d.Name))
                .ForMember(src => src.ProductId, des => des.MapFrom(d => d.Id))
                .ForSourceMember(src => src.VisitCount, des => des.Ignore());
        }

        private static void ConfigureProductIncludePagedResult()
        {
            Mapper.CreateMap<Product, ProductDto>().IncludePagedResultMapping()
                .ForMember(src => src.ProductName, des => des.MapFrom(d => d.Name))
                .ForMember(src => src.ProductId, des => des.MapFrom(d => d.Id));
        }

        private static void ConfigureProductBrand()
        {
            Mapper.CreateMap<ProductBrand, ProductBrandDto>();
        }

        private static void ConfigureProductCategory()
        {
            Mapper.CreateMap<ProductCategory, ProductCategoryDto>();
        }

        private static void ConfigureProductTag()
        {
            Mapper.CreateMap<ProductTag, ProductTagDto>()
                   .ForSourceMember(src => src.Products, des => des.Ignore());
        }

        private static void ConfigureProductColor()
        {
            Mapper.CreateMap<ProductColor, ProductColorDto>()
                .ForSourceMember(src => src.Products, des => des.Ignore());
        }

        private static void ConfigureProductPicture()
        {
            Mapper.CreateMap<ProductPicture, ProductPictureDto>()
                .ForMember(src => src.PictureId, src => src.MapFrom(s => s.Id))
                .ForSourceMember(src => src.Products, des => des.Ignore());
        }

        private static void ConfigureProductSize()
        {
            Mapper.CreateMap<ProductSize, ProductSizeDto>()
                    .ForSourceMember(src => src.Products, des => des.Ignore());
        }

        private static void ConfigureProductAttribute()
        {
            Mapper.CreateMap<ProductAttribute, ProductAttributeDto>()
                .ForMember(src => src.AttributeId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureProductAttributeOption()
        {
            Mapper.CreateMap<ProductAttributeOption, ProductAttributeOpetionDto>();
        }

        private static void ConfigureProductIcon()
        {
            Mapper.CreateMap<ProductIcon, ProductIconDto>()
                .ForMember(src => src.IconId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureProductComment()
        {
            Mapper.CreateMap<ProductComment, ProductCommentDto>()
                .ForMember(src => src.CommentId, des => des.MapFrom(c => c.Id));
        }

        private static void ConfigureSpecialState()
        {
            Mapper.CreateMap<ProductSpecialState, ProductSpecialStateDto>();
        }

        #endregion

        #region Store
        private static void ConfigureStoreMapper()
        {
            ConfigureStore();
            ConfigureStoreIncludePagedResult();
            ConfigureStorePicture();
            ConfigureStoreComment();
        }

        private static void ConfigureStore()
        {
            Mapper.CreateMap<Store, StoreDto>()
                .ForMember(src => src.StoreId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureStoreIncludePagedResult()
        {
            Mapper.CreateMap<Store, StoreDto>().IncludePagedResultMapping()
               .ForMember(src => src.StoreId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureStorePicture()
        {
            Mapper.CreateMap<StorePicture, StorePictureDto>()
                .ForMember(src => src.PictureId, src => src.MapFrom(s => s.Id));
        }

        private static void ConfigureStoreComment()
        {
            Mapper.CreateMap<StoreComment, StoreCommentDto>()
                 .ForMember(src => src.CommentId, src => src.MapFrom(s => s.Id));
        }

        #endregion
    }

    #endregion

    #region Extension
    internal static class MappingExtensions
    {
        public static IMappingExpression<TSrc, TDest> IncludePagedResultMapping<TSrc, TDest>(this IMappingExpression<TSrc, TDest> expression)
        {
            Mapper.CreateMap<PagingQueryResponse<TSrc>, PagingQueryResponse<TDest>>()
                .ForMember(dest => dest.HasMoreResults, opt => opt.MapFrom(src => src.HasMoreResults))
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.CurrentPage))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));

            return expression;
        }
    }

    #endregion
}

