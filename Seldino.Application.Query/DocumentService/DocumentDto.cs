using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.DocumentService
{
    public class AboutDto
    {
        public string Body { get; set; }

        public IList<DocumentPictureDto> DocumentPictures { get; set; }
    }

    public class DocumentDto
    {
        public Guid DocumentId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public AboutDto About { get; set; }

        public RuleDto Rule { get; set; }

        public GuideDto Guide { get; set; }

        public InformationDto Information { get; set; }

        public bool IsDefault { get; set; }

        public IList<SocialMediaDto> SocialMedias { get; set; }
    }

    public class DocumentPictureDto
    {
        public Guid PictureId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }

    public class GuideDto
    {
        public string Body { get; set; }

        public IList<DocumentPictureDto> DocumentPictures { get; set; }

    }

    public class InformationDto
    {
        public string Body { get; set; }
    }

    public class RuleDto
    {
        public string Body { get; set; }
    }

    public class SocialMediaDto
    {
        public string Url { get; set; }

        public SocialMediaOptionDto SocialMediaOption { get; set; }
    }

    public class SocialMediaOptionDto
    {
        public string Name { get; set; }

        public byte[] Icon { get; set; }
    }
}
