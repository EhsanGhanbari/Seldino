using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.BlogService
{
    public class BlogPostDto
    {
        public Guid BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public BlogCategoryDto BlogCategory { get; set; }
        public ICollection<BlogTagDto> BlogTags { get; set; }
        public ICollection<BlogPictureDto> BlogPictures { get; set; }
    }

    public class BlogTagDto
    {
        public string Name { get; set; }
    }

    public class BlogCategoryDto
    {
        public string Name { get; set; }
    }

    public class BlogPictureDto
    {
        public Guid PictureId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
