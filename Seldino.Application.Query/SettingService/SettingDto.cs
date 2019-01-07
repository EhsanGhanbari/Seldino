using System;
using Seldino.Application.Query.ProductService;

namespace Seldino.Application.Query.SettingService
{
    public class SettingDto
    {
        public BannerSettingDto BannerSetting { get; set; }

        public BasicSettingDto BasicSetting { get; set; }

        public BasketSettingDto BasketSetting { get; set; }

        public BlogSettingDto BlogSetting { get; set; }

        public DiscountSettingDto DiscountSetting { get; set; }

        public DocumentSettingDto DocumentSetting { get; set; }

        public OrderSettingDto OrderSetting { get; set; }

        public ProductSettingDto ProductSetting { get; set; }

        public StoreSettingDto StoreSetting { get; set; }

        public SeoSettingDto SeoSetting { get; set; }

    }

    public class BannerSettingDto
    {
        public bool IsAutoPublished { get; set; }
    }

    public class BasicSettingDto
    {
        #region Website

        public string WebsiteTitle { get; set; }

        public string WebsiteUrl { get; set; }

        #endregion
    }

    public class BasketSettingDto
    {
        public bool EmailNotificationEnabled { get; set; }
    }

    public class BlogSettingDto
    {
        #region Comment

        public bool IsCommentAutoPublished { get; set; }

        public int CommentLength { get; set; }

        public int CommentIntervalTime { get; set; }

        #endregion
    }

    public class DiscountSettingDto
    {
    }

    public class DocumentSettingDto
    {
    }

    public class OrderSettingDto
    {
    }

    public class ProductSettingDto
    {
        #region Product

        public bool IsAutoPublished { get; set; }

        #endregion

        #region Image

        public string ImagePrefixAddress { get; set; }

        #endregion

        #region Comment

        public bool IsCommentAutoPublished { get; set; }

        public int CommentLength { get; set; }

        public int CommentIntervalTime { get; set; }

        #endregion
    }

    public class StoreSettingDto
    {
        public bool IsAutoPublished { get; set; }
    }

    public class SeoSettingDto
    {
        public string DefaultTitle { get; set; }

        public string DefaultMetaKeywords { get; set; }

        public string DefaultMetaDescription { get; set; }

        public string[] ImagePath { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string Link { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}

