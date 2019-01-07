using System;

namespace Seldino.CrossCutting.Enums
{
    //[Flags]
    public enum DiscountLimitation : byte
    {
        Unlimited = 1,
        TimeBased = 2,
        PurchaseBased = 4,
    }

    //[Flags]
    public enum DiscountType : byte
    {
        AssignedToOrderTotal = 1,
        AssignedToStore = 2,
        AssignedToUser = 4
    }
}
