using System.Web;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Enums;
using System;

namespace Seldino.Application.Command.BannerHandler
{
    public interface IBannerCommand : ICommand
    {
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        PictureCommand Picture { get; set; }

        BannerType BannerType { get; set; }

        decimal Fee { get; set; }

        string Url { get; set; }

        string Caption { get; set; }

        bool IsConfirmed { get; set; }

        HttpPostedFileBase HttpPostedFileBase { get; set; }

        Guid UserId{ get; set; }
    }

    [Validator(typeof(BannerCommandValidation))]
    public class BannerCommand : IBannerCommand
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public PictureCommand Picture { get; set; }

        public BannerType BannerType { get; set; }

        public decimal Fee { get; set; }

        public string Url { get; set; }

        public string Caption { get; set; }

        public bool IsConfirmed { get; set; }

        public HttpPostedFileBase HttpPostedFileBase { get; set; }

        public Guid UserId { get; set; }
    }

    public class CreateBannerCommand : BannerCommand
    {
    }

    public class EditBannerCommand : BannerCommand
    {
        public Guid BannerId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }

    public class DeactivateBannerCommand : ICommand
    {
        public Guid[] BannerIds { get; set; }
    }

    public class ActivateBannerCommand : ICommand
    {
        public Guid[] BannerIds { get; set; }
    }

    public class DeleteBannerCommand : ICommand
    {
        public Guid[] BannerIds { get; set; }
    }

    public class ConfirmBannerCommand : ICommand
    {
        public Guid[] BannerIds { get; set; }
    }
}
