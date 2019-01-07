using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldino.Application.Query.PaymentService
{
    internal sealed class PaymentQueryMessage
    {
        public const string LoadingInvoiceFaild = "صدور فاکتور با مشکل مواجه شد";
        public const string LoadingPaymentFaild = "دریافت اطلاعات پرداخت با مشکل مواجه شد";

    }
}
