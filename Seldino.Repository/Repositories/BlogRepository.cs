using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Seldino.Domain.BlogAggregation;
using Seldino.Domain.BlogAggregation.BlogComments;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class BlogRepository : RepositoryBase<BlogPost>, IBlogRepository
    {
        public BlogRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #region BlogPost
        public IList<BlogPost> GetAllBlogPosts()
        {
            return DataContext.BlogPosts.Where(p => p.IsDeleted == false)
                .OrderByDescending(c => c.CreationDate).ToList();
        }

        public IList<BlogPost> GetAllBlogPostByTag(string value)
        {
            return DataContext.BlogPosts.Where(p => p.IsDeleted == false)
                .Include(b => b.BlogTags.Select(t => t.Name == value))
                .OrderByDescending(d => d.CreationDate).ToList();
        }

        public IList<BlogPost> GetAllBlogPostByCategory(string value)
        {
            return DataContext.BlogPosts.Where(p => p.IsDeleted == false)
               .Include(b => b.Category == value)
               .OrderByDescending(d => d.CreationDate).ToList();
        }

        public BlogPost GetBlogPost(int year, int month, int day, string urlSlug)
        {
            return DataContext.BlogPosts.SingleOrDefault(p => p.CreationDate.Year == year &&
                                                              p.CreationDate.Month == month &&
                                                              p.CreationDate.Day == day &&
                                                              p.UrlSlug == urlSlug);
        }

        #endregion

        #region BlogTag

        public void DeleteBlogTag(string value)
        {
            var tag = DataContext.BlogTags.SingleOrDefault(b => b.Name == value);
            if (tag != null) tag.IsDeleted = true;
            DataContext.Entry(tag).State = EntityState.Modified;
        }

        public BlogTag GetBlogTagByValue(string value)
        {
            return DataContext.BlogTags.SingleOrDefault(t => t.Name == value);
        }

        public IList<BlogTag> GetAllBlogTags()
        {
            return DataContext.BlogTags.Where(t => t.IsDeleted == false).ToList();
        }

        public IList<BlogTag> GetAllBlogTags(string keyword, string category)
        {
            return string.IsNullOrWhiteSpace(keyword)
                   ? DataContext.BlogTags.Where(t => t.IsDeleted == false
                      && t.BlogCategories.Select(c => c.Name == category).FirstOrDefault()).ToList()

                  : DataContext.BlogTags.Where(t => t.IsDeleted == false && t.Name.Contains(keyword)
                      && t.BlogCategories.Select(c => c.Name == category).FirstOrDefault()).ToList();
        }

        public void DeleteBlogCategory(string value)
        {
            var tag = DataContext.BlogCategories.SingleOrDefault(b => b.Name == value);
            if (tag != null) tag.IsDeleted = true;
            DataContext.Entry(tag).State = EntityState.Modified;
        }

        #endregion

        #region BlogCategory

        public BlogCategory GetBlogCategoryValue(string value)
        {
            return DataContext.BlogCategories.SingleOrDefault(c => c.Name == value);
        }

        public IList<BlogCategory> GetAllBlogCategories(string keyword)
        {
            return string.IsNullOrWhiteSpace(keyword)
               ? DataContext.BlogCategories.Where(t => t.IsDeleted == false).ToList()
               : DataContext.BlogCategories.Where(t => t.IsDeleted == false && t.Name.Contains(keyword)).ToList();
        }

        #endregion
    }

    internal class BlogCommentRepository : RepositoryBase<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
