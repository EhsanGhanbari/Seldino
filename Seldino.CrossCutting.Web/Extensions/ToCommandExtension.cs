using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command;
using Seldino.Application.Command.BannerHandler;
using Seldino.Application.Command.BlogHandler;
using Seldino.Application.Command.DiscountHandler;
using Seldino.Application.Command.DocumentHandler;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Command.ProductHandler;
using Seldino.Application.Command.StoreHandler;
using Seldino.Application.Query.BannerService;
using Seldino.Application.Query.BlogService;
using Seldino.Application.Query.DiscountService;
using Seldino.Application.Query.DocumentService;
using Seldino.Application.Query.MembershipService;
using Seldino.Application.Query.NotificationService;
using Seldino.Application.Query.ProductService;
using Seldino.Application.Query.StoreService;

namespace Seldino.CrossCutting.Web.Extensions
{
    public static class ToCommandExtension
    {
        #region Banner

        public static EditBannerCommand ToCommand(this BannerDto banner)
        {
            return new EditBannerCommand
            {
                BannerId = banner.BannerId,
                BannerType = banner.BannerType,
                Caption = banner.Caption,
                EndDate = banner.EndDate,
                Fee = banner.Fee,
                IsConfirmed = banner.IsConfirmed,
                Picture = banner.Picture.ToCommand(),
                CreationDate = banner.CreationDate,
                LastUpdateDate = banner.LastUpdateDate,
                StartDate = banner.StartDate,
                Url = banner.Url
            };
        }

        public static IList<EditBannerCommand> ToCommand(this IEnumerable<BannerDto> banners)
        {
            return banners.Select(b => b.ToCommand()).ToList();
        }

        public static IList<PictureCommand> ToCommand(this IEnumerable<BannerPictureDto> pictures)
        {
            return pictures.Select(p => p.ToCommand()).ToList();
        }

        private static PictureCommand ToCommand(this BannerPictureDto picture)
        {
            return new PictureCommand
            {
                Address = picture.Address,
                PictureId = picture.PictureId,
                Name = picture.Name
            };
        }

        #endregion

        #region Basket
        #endregion

        #region Blog

        public static EditBlogPostCommand ToCommand(this BlogPostDto blogPost)
        {
            return new EditBlogPostCommand
            {
                Title = blogPost.Title,
                Body = blogPost.Body,
                BlogTags = blogPost.BlogTags.ToCommand(),
              //  BlogCategories = blogPost.BlogCategory.ToCommand(),
                BlogPictures = blogPost.BlogPictures.ToCommand()
            };
        }

        public static IList<BlogTagCommand> ToCommand(this IEnumerable<BlogTagDto> blogTags)
        {
            return blogTags.Select(t => t.ToCommand()).ToList();
        }

        public static BlogTagCommand ToCommand(this BlogTagDto blogTag)
        {
            return new BlogTagCommand
            {
                Name = blogTag.Name
            };
        }

        public static IList<BlogCategoryCommand> ToCommand(this IEnumerable<BlogCategoryDto> blogCategories)
        {
            return blogCategories.Select(t => t.ToCommmand()).ToList();
        }

        private static BlogCategoryCommand ToCommmand(this BlogCategoryDto blogCategory)
        {
            return new BlogCategoryCommand
            {
                Name = blogCategory.Name
            };
        }

        private static IList<BlogPictureCommand> ToCommand(this IEnumerable<BlogPictureDto> blogPictures)
        {
            return blogPictures.Select(t => t.ToCommand()).ToList();
        }

        private static BlogPictureCommand ToCommand(this BlogPictureDto blogPicture)
        {
            return new BlogPictureCommand
            {
                Name = blogPicture.Name,
                Address = blogPicture.Address,
                PictureId = blogPicture.PictureId
            };
        }

        #endregion

        #region Discount

        public static EditDiscountCommand ToCommand(this DiscountDto discount)
        {
            return new EditDiscountCommand
            {
                DiscountId = discount.DiscountId,
                Name = discount.Name,
                Amount = discount.Amount,
                DiscountLimitation = discount.DiscountLimitation,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                Stopped = discount.Stopped
            };
        }

        #endregion

        #region Document

        public static EditDocumentCommand ToCommand(this DocumentDto document)
        {
            return new EditDocumentCommand
            {
                IsDefault = document.IsDefault,
                DocumentId = document.DocumentId,
                CreationDate = document.CreationDate,
                LastUpdateDate = document.LastUpdateDate,
                AboutCommand = document.About.ToCommand(),
                RuleCommand = document.Rule.ToCommand(),
                SocialMedias = document.SocialMedias.ToCommand(),
                GuideCommand = document.Guide.ToCommand(),
                InformationCommand = document.Information.ToCommand(),
                SocialMediaCommands = document.SocialMedias.ToCommand()
            };
        }

        private static GuideCommand ToCommand(this GuideDto guide)
        {
            return new GuideCommand
            {
                Body = guide.Body
            };
        }

        private static InformationCommand ToCommand(this InformationDto information)
        {
            return new InformationCommand
            {
                Body = information.Body
            };
        }

        private static AboutCommand ToCommand(this AboutDto about)
        {
            return new AboutCommand
            {
                Body = about.Body,
                PictureCommands = about.DocumentPictures.ToCommand()
            };
        }

        private static IList<PictureCommand> ToCommand(this IEnumerable<DocumentPictureDto> pictures)
        {
            return pictures.Select(s => s.ToCommand()).ToList();
        }

        private static PictureCommand ToCommand(this DocumentPictureDto picture)
        {
            return new PictureCommand
            {
                Address = picture.Address,
                Name = picture.Name,
                PictureId = picture.PictureId
            };
        }

        private static RuleCommand ToCommand(this RuleDto rule)
        {
            return new RuleCommand
            {
                Body = rule.Body
            };
        }

        private static IList<SocialMediaCommand> ToCommand(this IEnumerable<SocialMediaDto> socialMedias)
        {
            return socialMedias.Select(s => s.ToCommand()).ToList();
        }

        private static SocialMediaCommand ToCommand(this SocialMediaDto socialMedia)
        {
            return new SocialMediaCommand
            {
                Url = socialMedia.Url,
                SocialMediaOption = socialMedia.SocialMediaOption.ToCommand()
            };
        }

        private static IList<SocialMediaOptionCommand> ToCommand(this IEnumerable<SocialMediaOptionDto> socialMediaOptions)
        {
            return socialMediaOptions.Select(s => s.ToCommand()).ToList();
        }

        private static SocialMediaOptionCommand ToCommand(this SocialMediaOptionDto socialMediaOption)
        {
            return new SocialMediaOptionCommand
            {
                Name = socialMediaOption.Name
            };
        }

        #endregion

        #region Membership

        public static UpdateProfileCommand ToCommand(this ProfileDto profile)
        {
            return new UpdateProfileCommand
            {
                UserId = profile.UserId,
                CreationDate = profile.CreationDate,
                LastUpdateDate = profile.LastUpdateDate,
                CellPhone = profile.CellPhone,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Picture = profile.Avatar != null ? profile.Avatar.ToCommand() : new PictureCommand()
            };
        }

        private static PictureCommand ToCommand(this ProfileAvatarDto profile)
        {
            return new PictureCommand
            {
                Name = profile.Name,
                Address = profile.Address,
                PictureId = profile.AvatarId
            };
        }

        #endregion

        #region Notification

        public static EditNotificationCommand ToCommand(this NotificationDto notification)
        {
            return new EditNotificationCommand
            {
                NotificationId = notification.NotificationId,
                Title = notification.Title,
                Body = notification.Body
            };
        }

        #endregion

        #region Order
        #endregion

        #region Payment
        #endregion

        #region Product

        public static EditProductCommand ToCommand(this ProductDto product)
        {
            return new EditProductCommand
            {
                ProductId = product.ProductId,
                Name = product.ProductName,
                OriginalName = product.OriginalName,
                Description = product.Description,
                Price = product.Price,
                OldPrice = product.OldPrice,
                DollarPrice = product.DollarPrice,
                OldDollarPrice = product.OldDollarPrice,
                CreationDate = product.CreationDate,
                LastUpdateDate = product.LastUpdateDate,
                ProductBrand = product.ProductBrand.ToCommand(),
                ProductCategory = product.ProductCategory.ToCommand(),
                ProductColors = product.ProductColors.ToCommand(),
                ProductPictures = product.ProductPictures.ToCommand(),
                ProductSizes = product.ProductSizes.ToCommand(),
                ProductTags = product.ProductTags.ToCommand()
            };
        }

        public static IList<ProductTagCommand> ToCommand(this IEnumerable<ProductTagDto> tags)
        {
            return tags.Select(t => t.ToCommand()).ToList();
        }

        private static ProductTagCommand ToCommand(this ProductTagDto tag)
        {
            return new ProductTagCommand
            {
                Name = tag.Name
            };
        }

        private static IList<ProductSizeCommand> ToCommand(this IEnumerable<ProductSizeDto> sizes)
        {
            return sizes.Select(s => s.ToCommand()).ToList();
        }

        private static ProductSizeCommand ToCommand(this ProductSizeDto size)
        {
            return new ProductSizeCommand
            {
                Name = size.Name
            };
        }

        private static IList<PictureCommand> ToCommand(this IEnumerable<ProductPictureDto> pictures)
        {
            return pictures.Select(p => p.ToCommand()).ToList();
        }

        private static PictureCommand ToCommand(this ProductPictureDto picture)
        {
            return new PictureCommand
            {
                Address = picture.Address,
                PictureId = picture.PictureId,
                Name = picture.Name
            };
        }

        public static IList<ProductColorCommand> ToCommand(this IEnumerable<ProductColorDto> colors)
        {
            return colors.Select(c => c.ToCommand()).ToList();
        }

        private static ProductColorCommand ToCommand(this ProductColorDto color)
        {
            return new ProductColorCommand
            {
                Name = color.Name,
                Code = color.Code,
            };
        }

        public static IList<ProductCategoryCommand> ToCommand(this IEnumerable<ProductCategoryDto> categories)
        {
            return categories.Select(c => c.ToCommand()).ToList();
        }

        public static ProductCategoryCommand ToCommand(this ProductCategoryDto category)
        {
            return new ProductCategoryCommand
            {
                Name = category.Name,
                //Picture = category.Icons.ToCommand() /ToDo
            };
        }

        public static IList<ProductBrandCommand> ToCommand(this IEnumerable<ProductBrandDto> brands)
        {
            return brands.Select(c => c.ToCommand()).ToList();
        }

        public static ProductBrandCommand ToCommand(this ProductBrandDto brand)
        {
            return new ProductBrandCommand
            {
                Name = brand.Name,
                Picture = brand.Icon!= null ? brand.Icon.ToCommand() : new PictureCommand()
            };
        }

        private static PictureCommand ToCommand(this ProductIconDto icon)
        {
            return new PictureCommand
            {
                Name = icon.Name,
                Address = icon.Address,
                PictureId = icon.IconId
            };
        }

        #endregion

        #region Store

        public static EditStoreCommand ToCommand(this StoreDto store)
        {
            return new EditStoreCommand
            {
                Name = store.Name,
                Phone = store.Phone
            };
        }

        #endregion
    }
}