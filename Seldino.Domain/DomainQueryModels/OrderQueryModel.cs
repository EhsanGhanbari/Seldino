using System;

namespace Seldino.Domain.QueryModels
{
    public class OrdersCountQueryModel
    {
        public Guid StoreId { get; set; }

        public string StoreName { get; set; }

        public int Completed { get; set; }

        public int InProcess { get; set; }

        public int Cancelled { get; set; }
    }
}
