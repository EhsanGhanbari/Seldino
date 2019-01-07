using System;
using System.Collections.Generic;
using AutoMapper;
using Seldino.Application.Query.OrderService;
using Seldino.Application.Query.ProductService;
using Seldino.Domain.BannerAggregation;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.QueryModels;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.DashboardService
{
    internal class DashboardQueryService : IDashboardQueryService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public DashboardQueryService(IBannerRepository bannerRepository,
            IDiscountRepository discountRepository,
            ILogger logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _bannerRepository = bannerRepository;
            _discountRepository = discountRepository;
            _logger = logger;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public DashboardLayoutQueryResponse GetDashboardLayout(DashboardLayoutQueryRequest request)
        {
            var response = new DashboardLayoutQueryResponse();

            try
            {
                var bannersCount = _bannerRepository.GetBannerCount(request.UserId);
                var discountsCount = _discountRepository.GetDiscountsCount(request.StoreId);
                var orders = _orderRepository.GetOrdersCount(request.StoreId);
                var products = _productRepository.GetProducsCount(request.UserId);

                //Banners
                response.DashboardLayout.ActiveBanners = bannersCount.Active;
                response.DashboardLayout.InactiveBanners = bannersCount.Inactive;

                //Discount
                response.DashboardLayout.ActiveDiscounts = discountsCount.Active;
                response.DashboardLayout.InactiveDiscounts = discountsCount.Inactive;

                //Order
                response.DashboardLayout.Orders = Mapper.Map<IList<OrdersCountQueryModel>, IList<OrdersCountDto>>(orders);

                //Product
                response.DashboardLayout.ActiveProducts = products.Active;
                response.DashboardLayout.InactiveDiscounts = products.Inactive;

            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }
    }
}
