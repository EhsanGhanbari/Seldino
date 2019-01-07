using System;
using Seldino.Domain.ProductAggregation;

namespace Seldino.Repository.QueryModels
{
    public class ProductDisplayListQueryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string[] ProductTags { get; set; }

        public string ProductCategory { get; set; }

        public string ProductPictures { get; set; }

        public string ProductBrand { get; set; }
    }

    public class ProducsCountQueryModel
    {
        public int Inactive { get; set; }

        public int Active { get; set; }
    }
}
