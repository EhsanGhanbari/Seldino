using System;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.GiftDeskAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.GiftDeskHandler
{
    internal class GiftDeskCommandHandler : 
        ICommandHandler<AddToGiftDeskCommand>,
        ICommandHandler<RemoveFromGiftDeskCommand>,
        ICommandHandler<UpdateGiftDeskSettingCommand>,
        ICommandHandler<VerifyRequestOfGiftDeskCommand>

    {
        private readonly IGiftDeskRepository _giftDeskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public GiftDeskCommandHandler(IGiftDeskRepository giftDeskRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _giftDeskRepository = giftDeskRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(AddToGiftDeskCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var giftDesk = new GiftDesk();
               
                _giftDeskRepository.Add(giftDesk);
                _unitOfWork.Commit();
                return new SuccessResult(GiftDeskCommandMessage.AddedToGiftDeskSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(GiftDeskCommandMessage.AddingToGiftDeskFaild);
            }
        }

        public ICommandResult Execute(RemoveFromGiftDeskCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Execute(UpdateGiftDeskSettingCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Execute(VerifyRequestOfGiftDeskCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
