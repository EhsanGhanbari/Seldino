using System;

namespace Seldino.CrossCutting.Enums
{
    [Flags]
    public enum ProductsSorting : byte
    {
        PriceHighToLow = 1,
        PriceLowToHigh = 2,
        CreatedOn = 4,
        MostVisited = 8
    }

    [Flags]
    public enum PriorityColor : byte
    {
        Lighten,
        Green,
        Blue,
        Yellow,
        Orange,
        Red,
        Black,
        White,
        Transparent
    }

    [Flags]
    public enum ImageSize
    {
        icon = 16,
        Mini = 32,
        HalfThumb = 48,
        Thumbnail = 64,
        Medium = 72,
        Large = 128,
        XLarge = 264,
        XXLarge = 512
    }

    [Flags]
    public enum Score
    {
        One = 1,
        Two = 2,
        Three = 4,
        Four = 8,
        Five = 16
    }
}
