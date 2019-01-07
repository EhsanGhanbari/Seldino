using System.Data;
using Seldino.Domain.BlogAggregation;
using Seldino.Domain.BlogAggregation.BlogComments;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class BlogPostConfiguration : EntityBaseConfiguration<BlogPost>
    {
        public BlogPostConfiguration()
        {
            ToTable("BlogPost", SchemaConstant.Blog);
            Property(b => b.Title).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(300);
            Property(b => b.UrlSlug).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(300);
            Property(b => b.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().IsMaxLength();

            Property(p => p.Category).HasMaxLength(50).IsRequired();
            HasRequired(t => t.BlogCategory).WithMany().HasForeignKey(pc => pc.Category).WillCascadeOnDelete(false);

            HasMany(pb => pb.BlogTags).WithMany(p => p.BlogPosts).Map(m =>
            {
                m.MapLeftKey("BlogPostId");
                m.MapRightKey("TagName");
                m.ToTable("Blog_BlogTag", SchemaConstant.Blog);
            });

            HasMany(pb => pb.BlogPictures).WithMany(p => p.BlogPosts).Map(m =>
            {
                m.MapLeftKey("BlogPostId");
                m.MapRightKey("BlogPictureId");
                m.ToTable("Blog_BlogPicture", SchemaConstant.Blog);
            });

            HasMany(pb => pb.BlogComments).WithMany(p => p.BlogPosts).Map(m =>
            {
                m.MapLeftKey("BlogPostId");
                m.MapRightKey("BlogCommentId");
                m.ToTable("Blog_BlogComment", SchemaConstant.Blog);
            });
        }
    }

    internal class BlogPictureConfiguration : EntityBaseConfiguration<BlogPicture>
    {
        public BlogPictureConfiguration()
        {
            ToTable("BlogPicture", SchemaConstant.Blog);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }

    internal class BlogCategoryConfiguration : ValueObjectBaseConfiguration<BlogCategory>
    {
        public BlogCategoryConfiguration()
        {
            ToTable("BlogCategory", SchemaConstant.Blog);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            HasMany(pb => pb.BlogTags).WithMany(p => p.BlogCategories).Map(m =>
            {
                m.MapLeftKey("CategoryName");
                m.MapRightKey("TagName");
                m.ToTable("BlogCategory_BlogTag", SchemaConstant.Blog);
            });
        }
    }

    internal class BlogTagConfiguration : ValueObjectBaseConfiguration<BlogTag>
    {
        public BlogTagConfiguration()
        {
            ToTable("BlogTag", SchemaConstant.Blog);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
        }
    }

    internal class BlogCommentConfiguration : EntityBaseConfiguration<BlogComment>
    {
        public BlogCommentConfiguration()
        {
            ToTable("BlogComment", SchemaConstant.Blog);
            Property(p => p.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(150);

            HasMany(p => p.BlogComments)
                .WithOptional()
                .HasForeignKey(pc => pc.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
