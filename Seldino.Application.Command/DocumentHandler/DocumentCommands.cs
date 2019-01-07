using Seldino.Application.Command.CommandHandler;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Seldino.Application.Command.DocumentHandler
{

    public interface IDocumentCommand : ICommand
    {
        bool IsDefault { get; set; }
        RuleCommand RuleCommand { get; set; }
        IList<SocialMediaCommand> SocialMedias { get; set; }
        AboutCommand AboutCommand { get; set; }
        GuideCommand GuideCommand { get; set; }
        InformationCommand InformationCommand { get; set; }
        IList<SocialMediaCommand> SocialMediaCommands { get; set; }
        Guid StoreId { get; set; }
    }

    public class DocumentCommand : IDocumentCommand
    {
        public Guid StoreId { get; set; }
        public bool IsDefault { get; set; }
        public RuleCommand RuleCommand { get; set; }
        public IList<SocialMediaCommand> SocialMedias { get; set; }
        public AboutCommand AboutCommand { get; set; }
        public GuideCommand GuideCommand { get; set; }
        public InformationCommand InformationCommand { get; set; }
        public IList<SocialMediaCommand> SocialMediaCommands { get; set; }
      
    }

    public class AddDocumentCommand : DocumentCommand
    {
    }

    public class EditDocumentCommand : DocumentCommand
    {
        public Guid DocumentId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }

    public class RuleCommand
    {
        [AllowHtml]
        public string Body { get; set; }
    }

    public class SocialMediaCommand
    {
        public string Url { get; set; }
        public SocialMediaOptionCommand SocialMediaOption { get; set; }
    }

    public class SocialMediaOptionCommand
    {
        public string Name { get; set; }
    }

    public class AboutCommand
    {
        [AllowHtml]
        public string Body { get; set; }
        public IList<PictureCommand> PictureCommands { get; set; }
        public IList<HttpPostedFileBase> HttpPostedFileBases { get; set; }
    }

    public class GuideCommand
    {
        [AllowHtml]
        public string Body { get; set; }
        public IList<PictureCommand> PictureCommands { get; set; }
        public IList<HttpPostedFileBase> HttpPostedFileBases { get; set; }
    }

    public class InformationCommand
    {
        [AllowHtml]
        public string Body { get; set; }
    }
}
