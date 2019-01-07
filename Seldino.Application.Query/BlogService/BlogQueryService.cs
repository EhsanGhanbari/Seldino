using System.Linq;
using AutoMapper;
using Seldino.CrossCutting.Caching;
using Seldino.Domain.BlogAggregation;
using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.BlogService
{
    internal class BlogQueryService : IBlogQueryService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICacheManager _cacheManager;

        public BlogQueryService(IBlogRepository blogRepository, ICacheManager cacheManager)
        {
            _blogRepository = blogRepository;
            _cacheManager = cacheManager;
        }

        public BlogPostDto GetBlogPostById(Guid blogPostId)
        {
            var blogPost = _blogRepository.GetById(blogPostId);
            return Mapper.Map<BlogPost, BlogPostDto>(blogPost);
        }

        public BlogPostDto GetBlogPost(BlogQuery query)
        {
            var blogPost = _blogRepository.GetBlogPost(query.Year, query.Month, query.Day, query.UrlSlug);
            return Mapper.Map<BlogPost, BlogPostDto>(blogPost);
        }

        public IList<BlogPostDto> GetAllBlogPostsByTag(string value)
        {
            var blogPost = _blogRepository.GetAllBlogPostByTag(value);
            return Mapper.Map<IList<BlogPost>, IList<BlogPostDto>>(blogPost);
        }

        public IList<BlogPostDto> GetAllBlogPostsByCategory(string value)
        {
            var blogPost = _blogRepository.GetAllBlogPostByCategory(value);
            return Mapper.Map<IList<BlogPost>, IList<BlogPostDto>>(blogPost);
        }

        public IList<BlogPostDto> GetAllBlogPosts(ref BlogQuery query)
        {
            var blogPosts = _blogRepository.GetAllBlogPosts();
            return Mapper.Map<IList<BlogPost>, IList<BlogPostDto>>(blogPosts);
        }

        public IList<BlogTagDto> GetAllBlogTags(BlogQuery query)
        {
            var blogTagDto = _cacheManager.Retrieve<IList<BlogTagDto>>("AllBlogTags");

            if (blogTagDto != null)
            {
                return string.IsNullOrWhiteSpace(query.Keyword)
                                  ? blogTagDto.ToList()
                                  : blogTagDto.Where(s => s.Name.Contains(query.Keyword)).ToList();
            }

            var blogTags = _blogRepository.GetAllBlogTags(query.Keyword, query.Value);
            blogTagDto = Mapper.Map<IList<BlogTag>, IList<BlogTagDto>>(blogTags);
            StoreAllBlogTagsInCache();
            return blogTagDto;
        }

        public IList<BlogCategoryDto> GetAllBlogCategories(BlogQuery query)
        {
            var blogcategoryDto = _cacheManager.Retrieve<IList<BlogCategoryDto>>("AllBlogCategories");

            if (blogcategoryDto != null)
            {
                return string.IsNullOrWhiteSpace(query.Keyword)
                                    ? blogcategoryDto.ToList()
                                    : blogcategoryDto.Where(s => s.Name.Contains(query.Keyword)).ToList();
            }

            var blogCategories = _blogRepository.GetAllBlogCategories(query.Keyword);
            blogcategoryDto = Mapper.Map<IList<BlogCategory>, IList<BlogCategoryDto>>(blogCategories);
            StoreAllBlogCategoriesInCache();
            return blogcategoryDto;
        }

        private void StoreAllBlogCategoriesInCache()
        {
            var categories = _blogRepository.GetAllBlogCategories(null);
            var blogcategoriesDto = Mapper.Map<IList<BlogCategory>, IList<BlogCategoryDto>>(categories);
            _cacheManager.Store("AllBlogCategories", blogcategoriesDto);
        }

        private void StoreAllBlogTagsInCache()
        {
            var tags = _blogRepository.GetAllBlogTags();
            var blogtagsDto = Mapper.Map<IList<BlogTag>, IList<BlogTagDto>>(tags);
            _cacheManager.Store("AllBlogTags", blogtagsDto);
        }
    }
}
