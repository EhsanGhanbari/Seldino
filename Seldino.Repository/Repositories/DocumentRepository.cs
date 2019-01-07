using Seldino.Domain.DocumentAggregation;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Seldino.Repository.Repositories
{
    internal class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IList<SocialMediaOption> GetAllSocialMediaOptions()
        {
            return DataContext.SocialMediaOptions.ToList();
        }

        public Document GetDefaultDocument()
        {
            return DataContext.Documents
                .Include(d => d.About)
                .Include(d => d.Guide)
                .Include(d => d.Information)
                .Include(d => d.SocialMedias)
                .Include(d => d.Rule)
                .SingleOrDefault(d => d.IsDefault && d.IsDeleted == false);
        }

        public Document GetDocumentByStoreId(Guid storeId)
        {
            return DataContext.Documents// Todo 
                .Include(d => d.About)
                .Include(d => d.Guide)
                .Include(d => d.Information)
                .Include(d => d.SocialMedias)
                .Include(d => d.Rule)
                .SingleOrDefault(d => d.IsDeleted == false);
        }

        public Document GetDocumentById(Guid documentId)
        {
            return DataContext.Documents
                .Where(f => f.Id == documentId)
                .Include(d => d.About)
                .Include(d => d.Guide)
                .Include(d => d.Information)
                .Include(d => d.SocialMedias)
                .Include(d => d.Rule)
                .SingleOrDefault(d => d.IsDefault && d.IsDeleted == false);
        }
    }
}
