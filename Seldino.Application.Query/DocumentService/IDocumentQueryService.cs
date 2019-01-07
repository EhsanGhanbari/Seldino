
namespace Seldino.Application.Query.DocumentService
{
    public interface IDocumentQueryService
    {
        DocumentQueryResponse GetDefaultDocument(DocumentQueryRequest request);

        DocumentQueryResponse GetDocumentById(DocumentQueryRequest request);

        DocumentQueryResponse GetDocumentByStoreId(DocumentQueryRequest request);

        SocialMediaQueryResponse GetSocialMediaOptions(SocialMediaQueryRequest request);
    }
}
