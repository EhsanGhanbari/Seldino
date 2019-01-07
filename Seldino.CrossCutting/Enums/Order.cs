using System;

namespace Seldino.CrossCutting.Enums
{
    [Flags]
    public enum OrderStatus : byte
    {
        InProcess = 1,
        Completed = 2,
        Cancelled = 4
    }

    [Flags]
    public enum GiftCardType : byte
    {
        Virtual = 1,
        Physical = 2,
    }
}
