using Seldino.Application.Query.LocationService;
using System;
using System.Collections.Generic;
using Seldino.Application.Query.DocumentService;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;

namespace Seldino.Application.Query.StoreService
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public LocationDto Location { get; set; }

        public bool IsInactive { get; set; }

        public DocumentDto Document { get; set; }

        public IList<Product> Products { get; set; }

        public IList<Discount> Discounts { get; set; }

        public IList<Favorite> Favorites { get; set; }

        public IList<StorePictureDto> Pictures { get; set; }

        public IList<StoreCommentDto> StoreComments { get; set; } 

        public IList<User> Users { get; set; } 
    }

    public class StorePictureDto
    {
        public Guid PictureId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string FullPath => Address + Name;

    }

    public class StoreCommentDto
    {
        public Guid CommentId { get; set; }

        public string Body { get; set; }
    }
}
