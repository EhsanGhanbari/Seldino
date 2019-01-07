using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.BlogService
{
    public interface IBlogQueryService
    {
        #region Post
        BlogPostDto GetBlogPostById(Guid blogPostId);
        BlogPostDto GetBlogPost(BlogQuery query);
        IList<BlogPostDto> GetAllBlogPostsByTag(string value);
        IList<BlogPostDto> GetAllBlogPostsByCategory(string value);
        IList<BlogPostDto> GetAllBlogPosts(ref BlogQuery query);
        #endregion

        #region Tags
        IList<BlogTagDto> GetAllBlogTags(BlogQuery query);
        #endregion

        #region Categories
        IList<BlogCategoryDto> GetAllBlogCategories(BlogQuery query);
        #endregion

    }
}
