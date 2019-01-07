namespace Seldino.CrossCutting.Web.Routings
{
    public class RouteConstants
    {
        #region System
        public static string RoutingNamespace = "Seldino.Web.UI.Controllers";
        public static string RoutingManagementNamespace = "Seldino.Web.UI.Controllers";

        #endregion

        #region Membership

        public static string MembershipSignIn = "MembershipSignIn";
        public static string MembershipSignOut = "MembershipSignOut";
        public static string MembershipRegister = "MembershipRegister";
        public static string MembershipForgotPassword = "MembershipForgotPassword";
        public static string MembershipUpdateProfile = "MembershipUpdateProfile";
        public static string MembershipChangePassword = "MembershipChangePassword";

        #endregion

        #region Basket

        public static string BasketCard = "BasketCard";

        #endregion

        #region Order

        public static string OrderPursuit = "OrderPursuit";

        #endregion

        #region Product

        public static string ProductDetail = "ProductDetail";
        public static string ProductBestSelling = "ProductBestSelling";
        public static string ProductPopular = "ProductPopular";
        public static string ProductMostVisited = "ProductMostVisited";
        public static string ProductDiscounted = "ProductDiscounted";
        public static string ProductBrand = "ProductBrand";
        public static string ProductCategory = "ProductCategory";
        public static string ProductTag = "ProductTag";

        #endregion

        #region Store

        public static string StoreList = "StoreList";
        public static string StoreListSearch = "StoreListSearch";
        public static string StoreDetail = "StoreDetail";
        public static string StoreBestSelling = "StoreBestSelling";
        public static string StoreBestSellingSearch = "StoreBestSellingSearch";
        public static string StoreDiscoutned = "StoreDiscoutned";
        public static string StoreDiscoutnedSearch = "StoreDiscoutnedSearch";
        public static string StoreAbout = "StoreAbout";
        public static string StoreRule = "StoreRule";
        public static string StoreGuide = "StoreGuide";
        public static string StoreInformation = "StoreInformation";

        #endregion
    }
}