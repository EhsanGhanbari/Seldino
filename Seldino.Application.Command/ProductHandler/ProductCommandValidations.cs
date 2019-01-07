using FluentValidation;

namespace Seldino.Application.Command.ProductHandler
{
    #region Product
    internal class ProductCommandValidation : AbstractValidator<ProductCommand>
    {
        public ProductCommandValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ProductValidationMessage.ProductNameIsRequired)
                .Length(2, 80).WithMessage(ProductValidationMessage.ProductNameIsTooLong);

            RuleFor(p => p.Description)
                .Length(10, 200).WithMessage(ProductValidationMessage.ProductDescriptionIsNotInRegularLenght);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ProductValidationMessage.ProductPriceIsRequired)
                .GreaterThan(0).WithMessage(ProductValidationMessage.ProductPriceHasIncorrectFormat);

            RuleFor(p => p.ProductBrand).SetValidator(new ProductBrandCommandValidator());
            RuleFor(p => p.ProductCategory).SetValidator(new ProductCategoryCommandValidator());
            RuleFor(p => p.ProductTags).SetCollectionValidator(new ProductTagCommandValidator());
            RuleFor(p => p.ProductColors).SetCollectionValidator(new ProductColorCommandValidator());
            RuleFor(p => p.ProductSizes).SetCollectionValidator(new ProductSizeCommandValidator());
        }
    }

    internal class ProductBrandCommandValidator : AbstractValidator<ProductBrandCommand>
    {
        internal ProductBrandCommandValidator()
        {
            RuleFor(b => b.Name).Length(2, 50).WithMessage(ProductValidationMessage.ProductBrandIsNotInRegularLenght);
        }
    }

    internal class ProductCategoryCommandValidator : AbstractValidator<ProductCategoryCommand>
    {
        internal ProductCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ProductValidationMessage.ProductCategoryIsRequired)
                .Length(2, 50).WithMessage(ProductValidationMessage.ProductCategoryIsNotInRegularLenght);
        }
    }

    internal class ProductTagCommandValidator : AbstractValidator<ProductTagCommand>
    {
        internal ProductTagCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage(ProductValidationMessage.ProductTagIsRequired)
                .Length(2, 50).WithMessage(ProductValidationMessage.ProductTagIsNotInRegularLenght);
        }
    }

    internal class ProductColorCommandValidator : AbstractValidator<ProductColorCommand>
    {
        internal ProductColorCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage(ProductValidationMessage.ProductColorIsRequired)
                .Length(2, 50).WithMessage(ProductValidationMessage.ProductColorIsNotInRegularLenght);
        }
    }

    internal class ProductSizeCommandValidator : AbstractValidator<ProductSizeCommand>
    {
        internal ProductSizeCommandValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage(ProductValidationMessage.ProductSizeIsRequired)
                .Length(2, 50).WithMessage(ProductValidationMessage.ProductSizeIsNotInRegularLenght);
        }
    }
    #endregion

    #region ProductComment
    internal class ProductCommentCommandValidator : AbstractValidator<ProductCommentCommand>
    {
        public ProductCommentCommandValidator()
        {
            RuleFor(t => t.Body).NotEmpty().WithMessage(ProductValidationMessage.ProductCommentBodyIsRequired)
               .Length(2, 150).WithMessage(ProductValidationMessage.ProductCommentBodyIsTooLong);
        }
    }
    #endregion

}
