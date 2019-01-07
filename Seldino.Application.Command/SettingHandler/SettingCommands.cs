using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.SettingHandler
{
    public interface ISettingCommand : ICommand
    {
        BannerSettingCommand BannerSetting { get; set; }

        BasicSettingCommand BasicSetting { get; set; }

        BasketSettingCommand BasketSetting { get; set; }

        BlogSettingCommand BlogSetting { get; set; }

        StoreSettingCommand StoreSetting { get; set; }

        ProductSettingCommand ProductSetting { get; set; }
    }

    public class SettingCommand : ISettingCommand
    {
        public BannerSettingCommand BannerSetting { get; set; }

        public BasicSettingCommand BasicSetting { get; set; }

        public BasketSettingCommand BasketSetting { get; set; }

        public BlogSettingCommand BlogSetting { get; set; }

        public StoreSettingCommand StoreSetting { get; set; }

        public ProductSettingCommand ProductSetting { get; set; }
    }

    public class EditSettingCommand : SettingCommand
    {

    }

    public class BannerSettingCommand
    {
        public bool IsAutoPublished { get; set; }
    }

    public class BasicSettingCommand
    {
        #region Website
        public string WebsiteTitle { get; set; }

        public string WebsiteUrl { get; set; }
        #endregion
    }

    public class BasketSettingCommand
    {
        public bool EmailNotificationEnabled { get; set; }
    }

    public class BlogSettingCommand
    {
        #region Comment

        public bool IsCommentAutoPublished { get; set; }

        public int CommentLength { get; set; }

        public int CommentIntervalTime { get; set; }

        #endregion
    }

    public class DiscountSettingCommand
    {

    }

    public class DocumentSettingCommand
    {

    }

    public class OrderSettingCommand
    {

    }

    public class ProductSettingCommand
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

    public class StoreSettingCommand
    {
        public bool IsAutoPublished
        { get; set; }
    }
}
