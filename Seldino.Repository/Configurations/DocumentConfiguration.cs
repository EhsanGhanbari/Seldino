using System.Data;
using Seldino.Domain.DocumentAggregation;
using Seldino.Repository.Infrastructure;
using Rule = Seldino.Domain.DocumentAggregation.Rule;

namespace Seldino.Repository.Configurations
{
    internal class DocumentConfiguration : EntityBaseConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            ToTable("Document", SchemaConstant.Document);
            Property(d => d.IsDefault).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            Property(d => d.AboutId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.About).WithMany().HasForeignKey(p => p.AboutId).WillCascadeOnDelete(false);

            Property(p => p.RuleId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(p => p.Rule).WithMany().HasForeignKey(p => p.RuleId).WillCascadeOnDelete(false);

            Property(d => d.GuideId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Guide).WithMany().HasForeignKey(p => p.GuideId).WillCascadeOnDelete(false);

            Property(d => d.InformationId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Information).WithMany().HasForeignKey(p => p.InformationId).WillCascadeOnDelete(false);

            HasMany(d => d.SocialMedias).WithMany(s => s.Documents).Map(m =>
            {
                m.MapLeftKey("DocumentId");
                m.MapRightKey("SocialMediaId");
                m.ToTable("Document_SocialMedia", "Document");
            });
        }
    }

    internal class RuleConfiguration : EntityBaseConfiguration<Rule>
    {
        public RuleConfiguration()
        {
            ToTable("Rule", SchemaConstant.Document);
            Property(r => r.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsMaxLength().IsRequired();
        }
    }

    internal class SocialMediaConfiguration : EntityBaseConfiguration<SocialMedia>
    {
        public SocialMediaConfiguration()
        {
            ToTable("SocialMedia", "Document");
            Property(s => s.Url).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200).IsRequired();

            Property(s => s.SocialMediaOptionName).HasMaxLength(50).IsRequired();
            HasRequired(s => s.SocialMediaOption).WithMany().HasForeignKey(p => p.SocialMediaOptionName).WillCascadeOnDelete(false);
        }
    }

    internal class SocialMediaOptionConfiguration : ValueObjectBaseConfiguration<SocialMediaOption>
    {
        public SocialMediaOptionConfiguration()
        {
            ToTable("SocialMediaOption", SchemaConstant.Document);
            HasKey(s => s.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(s => s.Icon).IsOptional();
        }
    }

    internal class AboutConfiguration : EntityBaseConfiguration<About>
    {
        public AboutConfiguration()
        {
            ToTable("About", SchemaConstant.Document);
            Property(a => a.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsMaxLength().IsRequired();

            HasMany(a => a.DocumentPictures).WithMany(p => p.Abouts).Map(m =>
            {
                m.MapLeftKey("AboutId");
                m.MapRightKey("PictureId");
                m.ToTable("About_Picture", "Document");
            });
        }
    }

    internal class GuideConfiguration : EntityBaseConfiguration<Guide>
    {
        public GuideConfiguration()
        {
            ToTable("Guide", SchemaConstant.Document);
            Property(g => g.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsMaxLength().IsRequired();

            HasMany(g => g.DocumentPictures).WithMany(p => p.Guides).Map(m =>
            {
                m.MapLeftKey("GuideId");
                m.MapRightKey("PictureId");
                m.ToTable("Guide_Picture", "Document");
            });
        }
    }

    internal class InformationConfiguration : EntityBaseConfiguration<Information>
    {
        public InformationConfiguration()
        {
            ToTable("Information", SchemaConstant.Document);
            Property(i => i.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsMaxLength().IsRequired();
        }
    }

    internal class DocumentPictureConfiguration : EntityBaseConfiguration<DocumentPicture>
    {
        public DocumentPictureConfiguration()
        {
            ToTable("Picture", SchemaConstant.Document);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }
}
