using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.DocumentAggregation
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        IList<SocialMediaOption> GetAllSocialMediaOptions();
        Document GetDefaultDocument();
        Document GetDocumentByStoreId(Guid storeId);
        Document GetDocumentById(Guid documentId);
    }
}
