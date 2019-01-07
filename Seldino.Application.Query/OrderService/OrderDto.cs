using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ShippingAggregation;

namespace Seldino.Application.Query.OrderService
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string PaymentTransactionId { get; set; }

        public bool OrderHasBeenPaidFor { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }

        public string ShippingCharge { get; set; }

        public string ShippingServiceCourierName { get; set; }

        public string ShippingServiceDescription { get; set; }

        public string Total { get; set; }

        //public string CustomerFirstName { get; set; }

        //public string CustomerSecondName { get; set; }

        // public DeliveryAddressView DeliveryAddress { get; set; }

        // public ShippingService ShippingService { get; set; }

        // public Location Location { get; set; }

        // public Payment Payment { get; set; }

    }

    public class OrderItemDto
    {

        public int Quantity { get; set; }

        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public string Price { get; set; }
    }

    public class OrderSummaryDto
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public bool IsSubmitted { get; set; }
    }

    public class OrdersCountDto
    {
        public Guid StoreId { get; set; }

        public string StoreName { get; set; }

        public int Completed { get; set; }

        public int InProcess { get; set; }

        public int Cancelled { get; set; }
    }
}
