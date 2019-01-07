using System.Collections.Generic;
using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.DocumentAggregation
{
    public class Document : EntityBase, IAggregateRoot
    {
        public Guid? RuleId { get; set; }

        public virtual Rule Rule { get; set; }

        public Guid? AboutId { get; set; }

        public virtual About About { get; set; }

        public Guid? GuideId { get; set; }

        public virtual Guide Guide { get; set; }

        public Guid? InformationId { get; set; }

        public virtual Information Information { get; set; }

        public bool IsDefault { get; set; }

        public virtual ICollection<SocialMedia> SocialMedias { get; set; }

        public void AddSocialMedia(SocialMedia socialMedia)
        {
            SocialMedias.Add(socialMedia);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
