using System.Collections.Generic;
using Seldino.Application.Query.ProductService;

namespace Seldino.Application.Query.BasketService
{
    public class BasketDto
    {
        public decimal ItemsTotal { get; set; }

        public int NumberOfItems { get; set; }

        public IList<BasketItemDto> BasketItems { get; set; } 
    }

    public class BasketItemDto
    {
        public QuantityDto Quantity { get; set; }

        public ProductDto Product { get; set; }
    }

    public class QuantityDto
    {
        public int Value { get; set; }
    }
}
