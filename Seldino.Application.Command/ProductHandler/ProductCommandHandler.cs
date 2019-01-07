using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seldino.CrossCutting.Caching;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.ProductAggregation.ProductRatings;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Helpers;

namespace Seldino.Application.Command.ProductHandler
{
    #region Constructore

    internal partial class ProductCommandHandler :
        ICommandHandler<CreateProductCommand>,
        ICommandHandler<EditProductCommand>,
        ICommandHandler<DeactivateProductCommand>,
        ICommandHandler<ActivateProductCommand>,
        ICommandHandler<MarkAsAvailableCommand>,
        ICommandHandler<MarkAsUnAvailableCommand>,
        ICommandHandler<DeleteProductCommand>,
        ICommandHandler<DeleteProductCategoryCommand>,
        ICommandHandler<DeleteProductTagCommand>,
        ICommandHandler<DeleteProductBrandCommand>,
        ICommandHandler<DeleteProductColorCommand>,
        ICommandHandler<DeleteProductSizeCommand>,
        ICommandHandler<ApplyProductDiscountCommand>,
        ICommandHandler<IncreaseProductVisitCountCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IProductRatingRepository _productRatingRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public ProductCommandHandler(
            IProductRepository productRepository,
            IMembershipRepository membershipRepository,
            IStoreRepository storeRepository,
            IProductCommentRepository productCommentRepository,
            IProductRatingRepository productRatingRepository,
            IDiscountRepository discountRepository,
            IUnitOfWork unitOfWork,
            ILogger logger,
            ICacheManager cacheManager)
        {
            _productRepository = productRepository;
            _membershipRepository = membershipRepository;
            _storeRepository = storeRepository;
            _productCommentRepository = productCommentRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cacheManager = cacheManager;
            _productRatingRepository = productRatingRepository;
            _discountRepository = discountRepository;
        }

        #endregion

        #region Product

        public ICommandResult Execute(CreateProductCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var product = new Product();
                AddProductAppurtenance(command, product);
                _productRepository.Add(product);
                _unitOfWork.Commit();
                return new SuccessResult(ProductCommandMessage.ProductCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductCreationFailed);
            }
        }

        public ICommandResult Execute(EditProductCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var product = _productRepository.GetProductDetailById(command.ProductId);
                ClearProductAppurtenance(product);
                AddProductAppurtenance(command, product);
                _productRepository.Edit(product);
                _unitOfWork.Commit();

                return new SuccessResult(ProductCommandMessage.ProductEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductEditionFailed);
            }
        }

        public ICommandResult Execute(DeactivateProductCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = DeactivateProduct(productId);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeactivationFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductActivatedSuccessfully);
        }

        public ICommandResult Execute(ActivateProductCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = ActivateProduct(productId);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductActivatedSuccessfully);
        }

        public ICommandResult Execute(MarkAsAvailableCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = MarkAsAvailable(productId);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductsDeletedSuccessufully);
        }

        public ICommandResult Execute(MarkAsUnAvailableCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = MarkAsUnAvailable(productId);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductsDeletedSuccessufully);
        }

        public ICommandResult Execute(DeleteProductCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = DeleteProduct(productId);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductsDeletedSuccessufully);
        }

        public ICommandResult Execute(ApplyProductDiscountCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var discount = _discountRepository.GetById(command.DiscountId);

                    if (discount == null)
                    {
                        //ToDo should be exception
                        return new FailureResult("قالب تخفیف یافت نشد");
                    }

                    var product = ApplyDiscount(productId, discount);
                    _productRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult("تخفیف اعمال شد");
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult("اعمال تخفیف با خطا مواجه شد");
        }

        public ICommandResult Execute(IncreaseProductVisitCountCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var product = _productRepository.GetById(command.ProductId);

                if (product != null)
                {
                    product.VisitCount = product.VisitCount + 1;
                    _productRepository.Edit(product);
                    _unitOfWork.Commit();
                    return new SuccessResult("");
                }

                return new FailureResult("");
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                return new FailureResult("");
            }
        }

        private void AddProductAppurtenance(IProductCommand command, Product product)
        {
            AddProduct(command, product);
            AddProductBrand(command, product);
            AddProductTag(command, product);
            AddProductCategory(command, product);
            AddProductColor(command, product);
            AddProductPicture(command, product);
            AddProductSize(command, product);
            AddProductAttribute(command, product);
            AddProductAttributeOption(command, product);
            AssigProductToUser(command, product);
            AssignProductToStore(command, product);
            AddProductSpecialState(command, product);
        }

        private static void ClearProductAppurtenance(Product product)
        {
            product.ClearTag();
            product.ClearColor();
            product.ClearPicture();
            product.ClearSize();
        }

        private static void AddProduct(IProductCommand command, Product product)
        {
            product.Name = command.Name;
            product.OriginalName = command.OriginalName;
            product.Description = command.Description;
            product.Price = command.Price;
            product.DollarPrice = command.DollarPrice;
            product.Slug = command.Name.GenerateSlug();
        }

        private static void AddProductPicture(IProductCommand command, Product product)
        {
            foreach (var productPicture in command.ProductPictures.Select(item => new ProductPicture
            {
                Name = item.Name,
                Address = item.Address,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            }))
            {
                product.AddPicture(productPicture);
            }
        }

        private void AddProductTag(IProductCommand command, Product product)
        {
            if (command.ProductTags == null) return;

            foreach (var item in command.ProductTags.Where(c => c.Name != null))
            {
                var tag = new ProductTag
                {
                    Name = item.Name,
                    CreationDate = DateTime.Now,
                    Creator = command.UserIdentity.Email
                };

                if (item.IsNew)
                {
                    product.AddTag(tag);
                }
                else
                {
                    var productTag = _productRepository.GetProductTagByValue(item.Name);
                    product.ProductTags.Add(productTag);
                }
            }
        }

        private void AddProductColor(IProductCommand command, Product product)
        {
            if (command.ProductColors == null) return;

            foreach (var item in command.ProductColors.Where(c => c.Name != null))
            {
                var color = new ProductColor
                {
                    Name = item.Name,
                    CreationDate = DateTime.Now,
                    Creator = command.UserIdentity.Email
                };

                if (item.IsNew)
                {
                    product.AddColor(color);
                }
                else
                {
                    var productColor = _productRepository.GetProductColorByValue(item.Name);
                    product.ProductColors.Add(productColor);
                }
            }
        }

        private void AddProductCategory(IProductCommand command, Product product)
        {
            if (command.ProductCategory.Name == null) return;
            product.Category = command.ProductCategory.Name;
        }

        private static void AddProductBrand(IProductCommand command, Product product)
        {
            if (command.ProductBrand.Name == null) return;

            var brand = new ProductBrand
            {
                Name = command.ProductBrand.Name,
                CreationDate = DateTime.Now,
                Creator = command.UserIdentity.Email
            };

            if (command.ProductBrand.IsNew)
            {
                product.ProductBrand = brand;
                //product.ProductCategory = new ProductCategory();
                //product.ProductCategory.AddBrand(brand);
            }
            else
            {
                product.Brand = command.ProductBrand.Name;
            }
        }

        private void AddProductSize(IProductCommand command, Product product)
        {
            if (command.ProductSizes == null) return;

            foreach (var item in command.ProductSizes.Where(c => c.Name != null))
            {
                var size = new ProductSize
                {
                    Name = item.Name,
                    CreationDate = DateTime.Now,
                    Creator = command.UserIdentity.Email
                };

                if (item.IsNew)
                {
                    product.AddSize(size);
                }
                else
                {
                    var productSize = _productRepository.GetProductSizeByValue(item.Name);
                    product.ProductSizes.Add(productSize);
                }
            }
        }

        private void AddProductAttribute(IProductCommand command, Product product)
        {
            if (command.ProductAttributes == null) return;

            foreach (var attribute in command.ProductAttributes)
            {
                if (!attribute.IsNew) continue;

                var productAttribute = _productRepository.GetProductAttribute(attribute.AttributeId);

                product.ProductAttributes.Add(productAttribute);

                foreach (var option in attribute.AttributeOptionCommands)
                {
                    var productAttributeOption = _productRepository.GetProductAttributeOption(option.Name);
                    foreach (var item in product.ProductAttributes)
                    {
                        item.AttributeOptions.Add(productAttributeOption);
                    }
                }
            }
        }

        private void AddProductAttributeOption(IProductCommand command, Product product)
        {
            if (command.ProductAttributeOptions == null) return;

            foreach (var item in command.ProductAttributeOptions)
            {
                var productAttributeOption = _productRepository.GetProductAttributeOption(item.Name);
                product.ProductAttributeOptions.Add(productAttributeOption);
            }
        }

        private void AssigProductToUser(IProductCommand command, Product product)
        {
            var user = _membershipRepository.GetById(command.UserIdentity.Id);
            product.Users.Add(user);
        }

        private void AssignProductToStore(IProductCommand command, Product product)
        {
            if (command.StoreCommands == null)
            {
                throw new NoStoreHasBeenChoosenForProductException(ProductExceptionMessage.ProductStoreIsNotDeterminded);
            }

            foreach (var item in command.StoreCommands)
            {
                var store = _storeRepository.GetById(item.StoreId);
                product.Stores.Add(store);
            }
        }

        private void AddProductSpecialState(IProductCommand command, Product product)
        {
            if (command.IsInSpecialState)
            {
                product.ProductSpecialState = new ProductSpecialState
                {
                    StartDate = command.ProductSpecialState.StartDate,
                    EndDate = command.ProductSpecialState.EndDate,
                    Description = command.ProductSpecialState.Description
                };
            }
        }

        private Product DeleteProduct(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            product.IsDeleted = true;
            return product;
        }

        private Product DeactivateProduct(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            product.IsInactive = true;
            return product;
        }

        private Product ActivateProduct(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            product.IsInactive = false;
            return product;
        }

        private Product MarkAsAvailable(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            product.IsUnavailable = false;
            return product;
        }

        private Product MarkAsUnAvailable(Guid productId)
        {
            var product = _productRepository.GetById(productId);
            product.IsUnavailable = true;
            return product;
        }

        private Product ApplyDiscount(Guid productId, Discount discount)
        {
            var product = _productRepository.GetById(productId);
            product.Discounts.Add(discount);
            return product;
        }

        #endregion

        #region Category

        /// <summary>
        /// Delete product category
        /// this command will be used only by admin
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeleteProductCategoryCommand command)
        {

            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var category in command.Values)
            {
                try
                {
                    _productRepository.DeleteProductCategory(category);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductCategoryDeletedSuccessufully);
        }

        #endregion

        #region Tag

        public ICommandResult Execute(DeleteProductTagCommand command)
        {

            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var tag in command.Values)
            {
                try
                {
                    _productRepository.DeleteProductTag(tag);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductTagDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductTagDeletedSuccessufully);
        }

        #endregion

        #region Brand

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeleteProductBrandCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var brand in command.Values)
            {
                try
                {
                    _productRepository.DeleteProductBrand(brand);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductBrandDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductBrandDeletedSuccessufully);
        }

        #endregion

        #region Color

        public ICommandResult Execute(DeleteProductColorCommand command)
        {
            if (command.Values == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var color in command.Values)
            {
                try
                {
                    _productRepository.DeleteProductColor(color);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductsDeletedSuccessufully);
        }

        #endregion

        #region Size

        public ICommandResult Execute(DeleteProductSizeCommand command)
        {
            if (command.Values == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var size in command.Values)
            {
                try
                {
                    _productRepository.DeleteProductSize(size);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(ProductCommandMessage.ProductSizeDeletionFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(ProductCommandMessage.ProductSizeDeletedSuccessfully);
        }

        #endregion

    }
}
