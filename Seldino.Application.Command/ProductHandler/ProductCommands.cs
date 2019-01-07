using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Web;
using Seldino.Application.Command.MembershipHandler;
using Seldino.Application.Command.StoreHandler;

namespace Seldino.Application.Command.ProductHandler
{
    #region Product

    public interface IProductCommand : ICommand
    {
        string Name { get; set; }

        string OriginalName { get; set; }

        string Description { get; set; }

        decimal Price { get; set; }

        decimal? OldPrice { get; set; }

        decimal? DollarPrice { get; set; }

        decimal? OldDollarPrice { get; set; }

        IList<PictureCommand> ProductPictures { get; set; }

        IList<ProductTagCommand> ProductTags { get; set; }

        IList<ProductColorCommand> ProductColors { get; set; }

        IList<ProductSizeCommand> ProductSizes { get; set; }

        ProductBrandCommand ProductBrand { get; set; }

        ProductCategoryCommand ProductCategory { get; set; }

        IList<ProductAttributeCommand> ProductAttributes { get; set; }

        IList<ProductAttributeOptionCommand> ProductAttributeOptions { get; set; }

        IList<StoreAssigneeCommand> StoreCommands { get; set; }

        bool IsInSpecialState { get; set; }

        ProductSpecialStateCommand ProductSpecialState { get; set; }

        IUserIdentity UserIdentity { get; set; }
    }

    [Validator(typeof(ProductCommandValidation))]
    public class ProductCommand : IProductCommand
    {
        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? DollarPrice { get; set; }

        public decimal? OldDollarPrice { get; set; }

        public IList<PictureCommand> ProductPictures { get; set; }

        public IList<ProductTagCommand> ProductTags { get; set; }

        public IList<ProductColorCommand> ProductColors { get; set; }

        public IList<ProductSizeCommand> ProductSizes { get; set; }

        public ProductBrandCommand ProductBrand { get; set; }

        public ProductCategoryCommand ProductCategory { get; set; }

        public IList<ProductAttributeCommand> ProductAttributes { get; set; }

        public IList<ProductAttributeOptionCommand> ProductAttributeOptions { get; set; }

        public IList<StoreAssigneeCommand> StoreCommands { get; set; }

        public bool IsInSpecialState { get; set; }

        public ProductSpecialStateCommand ProductSpecialState { get; set; }

        public IUserIdentity UserIdentity { get; set; }

        public IEnumerable<HttpPostedFileBase> HttpPostedFileBases { get; set; }
    }

    public class CreateProductCommand : ProductCommand
    {
    }

    public class EditProductCommand : ProductCommand
    {
        public Guid ProductId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }

    public class ActivateProductCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class DeactivateProductCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class MarkAsAvailableCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class MarkAsUnAvailableCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class DeleteProductCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class IncreaseProductVisitCountCommand : ICommand
    {
        public Guid ProductId { get; set; }
    }

    #endregion

    #region Product Brand
    public class DeleteProductBrandCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    public class ProductBrandCommand
    {
        public string Name { get; set; }

        public PictureCommand Picture { get; set; }

        public bool IsNew { get; set; }

        public bool IsSelected { get; set; }
    }

    #endregion

    #region Product Category

    public class DeleteProductCategoryCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    public class ProductCategoryCommand
    {
        public string Name { get; set; }

        public PictureCommand Picture { get; set; }

        public bool IsNew { get; set; }

        public bool IsSelected { get; set; }

        public IList<ProductTagCommand> ProductTags { get; set; }

        public IList<ProductBrandCommand> BrandCommands { get; set; }
    }

    #endregion

    #region Product Tag

    public class DeleteProductTagCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    public class ProductTagCommand
    {
        public string Name { get; set; }

        public bool IsNew { get; set; }

        public bool IsSelected { get; set; }

        public PictureCommand Picture { get; set; }
    }

    #endregion

    #region Product Color
    public class ProductColorCommand
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public PictureCommand Picture { get; set; }

        public bool IsNew { get; set; }

        public bool IsSelected { get; set; }
    }

    public class DeleteProductColorCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    #endregion

    #region Product Size

    public class ProductSizeCommand
    {
        public string Name { get; set; }

        public bool IsNew { get; set; }
    }

    public class DeleteProductSizeCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    #endregion

    #region Product Attribute

    public class ProductAttributeCommand
    {
        public Guid AttributeId { get; set; }

        public string Name { get; set; }

        public bool IsNew { get; set; }

        public IList<ProductAttributeOptionCommand> AttributeOptionCommands { get; set; }
    }

    public class ProductAttributeOptionCommand
    {
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }

    #endregion

    #region Product SpecialState

    public class ProductSpecialStateCommand
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }

    #endregion

    #region Product Comment

    public interface IProductCommentCommand : ICommand
    {
        Guid ProductId { get; set; }

        Guid UserId { get; set; }

        string Body { get; set; }

        DateTime CreationDate { get; set; }

        DateTime LastUpdateDate { get; set; }

        Guid CommentId { get; set; }
    }

    [Validator(typeof(ProductCommentCommandValidator))]
    public class ProductCommentCommand : IProductCommentCommand
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public Guid CommentId { get; set; }
    }

    public class CreateProductCommentCommand : ProductCommentCommand
    {
    }

    public class EditProductCommentCommand : ProductCommentCommand
    {
    }

    public class DeleteProductCommentCommand : ICommand
    {
        public Guid CommentId { get; set; }
    }

    public class ReplyToProductCommentCommand : ProductCommentCommand
    {
    }

    #endregion

    #region Product Rating

    public interface IRateProductCommand : ICommand
    {
        Guid ProductId { get; set; }

        Guid UserId { get; set; }

        Score Score { get; set; }
    }

    public class RateProductCommand : IRateProductCommand
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public Score Score { get; set; }
    }


    #endregion

    #region Favorite
    public class AddProductToFavoriteCommand : ICommand
    {
        public Guid UserId { get; set; }

        public Guid[] ProductIds { get; set; }

        public string Description { get; set; }
    }

    public class RemoveProductFromFavoriteCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    #endregion

    public class ApplyProductDiscountCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }

        public Guid DiscountId { get; set; }
    }
}
