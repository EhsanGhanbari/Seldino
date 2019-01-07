using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation
{
    public interface IBlogRepository : IRepositoryBase<BlogPost>
    {
        #region BlogPost

        IList<BlogPost> GetAllBlogPosts();
        IList<BlogPost> GetAllBlogPostByTag(string value);
        IList<BlogPost> GetAllBlogPostByCategory(string value);
        BlogPost GetBlogPost(int year, int month, int day, string urlSlug);


        #endregion

        #region BlogTag
        void DeleteBlogTag(string value);
        BlogTag GetBlogTagByValue(string value);
        IList<BlogTag> GetAllBlogTags();
        IList<BlogTag> GetAllBlogTags(string keyword, string category);
        #endregion

        #region BlogCategory
        void DeleteBlogCategory(string value);
        BlogCategory GetBlogCategoryValue(string value);
        IList<BlogCategory> GetAllBlogCategories(string keyword);

        #endregion
    }
}
