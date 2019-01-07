using System;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using System.Collections.Generic;
using System.Web;

namespace Seldino.Application.Command.StoreHandler
{
    public interface IStoreCommand : ICommand
    {
        Guid UserId { get; set; }

        Guid StoreId { get; set; }

        string Name { get; set; }

        string Phone { get; set; }

        LocationCommand Location { get; set; }

        IList<PictureCommand> Pictures { get; set; }

        IEnumerable<HttpPostedFileBase> HttpPostedFileBases { get; set; }
    }

    [Validator(typeof(StoreCommandValidation))]
    public class StoreCommand : IStoreCommand
    {
        public Guid UserId { get; set; }

        public Guid StoreId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public LocationCommand Location { get; set; }

        public IList<PictureCommand> Pictures { get; set; }

        public IEnumerable<HttpPostedFileBase> HttpPostedFileBases { get; set; }
    }

    public class StoreAssigneeCommand
    {
        public Guid StoreId { get; set; }

        public string Name { get; set; }
    }

    public class CreateStoreCommand : StoreCommand
    {
    }

    public class EditStoreCommand : StoreCommand
    {
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }

    public class DeleteStoreCommand : ICommand
    {
        public Guid[] StoreIds { get; set; }
    }

    public class DeactiveStoreCommand : ICommand
    {
        public Guid[] StoreIds { get; set; }
    }

    public class ActivateStoreCommand : ICommand
    {
        public Guid[] StoreIds { get; set; }
    }

    public class AddStoreToFavoriteCommand : ICommand
    {
        public Guid UserId { get; set; }

        public Guid[] StoreIds { get; set; }

        public string Description { get; set; }
    }

    public class RemoveStoreFromFavoriteCommand : ICommand
    {
        public Guid[] FavoriteIds { get; set; }
    }

    public interface IStoreCommentCommand : ICommand
    {
        Guid StoreId { get; set; }

        Guid UserId { get; set; }

        string Body { get; set; }

        DateTime CreationDate { get; set; }

        DateTime LastUpdateDate { get; set; }

        Guid CommentId { get; set; }
    }

    public class StoreCommentCommand : IStoreCommentCommand
    {
        public Guid StoreId { get; set; }

        public Guid UserId { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public Guid CommentId { get; set; }
    }

    public class CreateStoreCommentCommand : StoreCommentCommand
    {
    }

    public class ReplyToStoreCommentCommand : StoreCommand
    {
    }

    public class DeleteStoreCommentCommand : ICommand
    {
        public Guid[] CommentIds { get; set; }
    }

    public class ApplyStoreDiscountCommand : ICommand
    {
        public Guid[] StoreIds { get; set; }

        public Guid DiscountId { get; set; }
    }
}
