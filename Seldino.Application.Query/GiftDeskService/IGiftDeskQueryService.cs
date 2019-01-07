namespace Seldino.Application.Query.GiftDeskService
{
    public interface IGiftDeskQueryService
    {
        GiftDesksQueryResponse GetGiftDesks(GiftDesksQueryRequest request);
    }
}
