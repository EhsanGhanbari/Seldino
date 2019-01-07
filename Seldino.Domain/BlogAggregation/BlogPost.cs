using System;
using System.Collections.Generic;
using Seldino.Domain.BlogAggregation.BlogComments;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation
{
    public class BlogPost : EntityBase, IAggregateRoot
    {
        private ICollection<BlogTag> _blogTags = new List<BlogTag>();
        private ICollection<BlogPicture> _blogPictures = new List<BlogPicture>();
        private ICollection<BlogCategory> _blogCategories = new List<BlogCategory>();
        private ICollection<BlogComment> _blogComments = new List<BlogComment>();

        public string Title { get; set; }
        public string Body { get; set; }
        public string UrlSlug { get; set; }

        public string Category { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }

        public ICollection<BlogTag> BlogTags
        {
            get { return _blogTags ?? (_blogTags = new List<BlogTag>()); }
            set { _blogTags = value; }
        }

        public ICollection<BlogPicture> BlogPictures
        {
            get { return _blogPictures ?? (_blogPictures = new List<BlogPicture>()); }
            set { _blogPictures = value; }
        }

        public ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            set { _blogComments = value; }
        }

        public void AddPicture(BlogPicture blogPicture)
        {
            _blogPictures.Add(blogPicture);
        }

        public void AddTag(BlogTag blogTag)
        {
            _blogTags.Add(blogTag);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
