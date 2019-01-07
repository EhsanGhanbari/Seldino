namespace Seldino.Application.Command.ProductHandler
{
    internal class ProductCategoryIsUsedException : CommandExceptions
    {
        public ProductCategoryIsUsedException(string message)
            : base(message)
        {
        }
    }

    internal class ProductTagIsUsedException : CommandExceptions
    {
        public ProductTagIsUsedException(string message)
            : base(message)
        {
        }
    }

    internal class ProductCommentOwnerIsWrongException : CommandExceptions
    {
        public ProductCommentOwnerIsWrongException(string message)
            : base(message)
        {
        }
    }

    internal class NoStoreHasBeenChoosenForProductException : CommandExceptions
    {
        public NoStoreHasBeenChoosenForProductException(string message) 
            : base(message)
        {
        }
    }
}
