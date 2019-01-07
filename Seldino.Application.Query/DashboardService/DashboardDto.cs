using System;
using System.Collections.Generic;
using Seldino.Application.Query.OrderService;

namespace Seldino.Application.Query.DashboardService
{
    public class DashboardLayoutDto
    {
        public int ActiveBanners { get; set; }

        public int InactiveBanners { get; set; }

        public int ActiveDiscounts { get; set; }

        public int InactiveDiscounts { get; set; }

        public int InProcessOrders { get; set; }

        public  int CompletedOrders { get; set; }

        public int CancelledOrders { get; set; }

        public int InactiveProducts { get; set; }

        public int ActiveProducts { get; set; }

        public IList<OrdersCountDto> Orders { get; set; }
    }
}


