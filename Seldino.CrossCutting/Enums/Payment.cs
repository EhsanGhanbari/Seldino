
using System;

namespace Seldino.CrossCutting.Enums
{
    [Flags]
    public enum PaymentStatus : byte
    {
        Pending = 1,
        Authorized = 2,
        Paid = 4,
        PartiallyRefunded = 8,
        Refunded = 16,
        Voided = 32
    }
}
