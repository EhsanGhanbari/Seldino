using System;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.GiftDeskHandler
{
    public interface IGiftDeskCommand : ICommand
    {
    }

    public class GiftDeskCommand : IGiftDeskCommand
    {
    }

    public class UpdateGiftDeskSettingCommand : ICommand
    {
        public bool IsPrivate { get; set; }
    }

    public class AddToGiftDeskCommand : GiftDeskCommand
    {
        public Guid[] ProductIds { get; set; }
      
    }

    public class RemoveFromGiftDeskCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }
    }

    public class VerifyRequestOfGiftDeskCommand : ICommand
    {
        public Guid UserId { get; set; }
    }

    public class RemoveFriendFromGiftDeskAccessCommand : ICommand
    {
        public Guid[] UserIds { get; set; }
    }
}
