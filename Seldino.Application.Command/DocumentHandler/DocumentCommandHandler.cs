using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.DocumentAggregation;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Linq;

namespace Seldino.Application.Command.DocumentHandler
{
    internal class DocumentCommandHandler :
        ICommandHandler<AddDocumentCommand>,
        ICommandHandler<EditDocumentCommand>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DocumentCommandHandler(IDocumentRepository documentRepository, IStoreRepository storeRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _documentRepository = documentRepository;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(AddDocumentCommand command)
        {
            try
            {
                var document = new Document();
                AddDocument(command, document);
                _documentRepository.Add(document);
                _unitOfWork.Commit();
                return new SuccessResult(DocumentCommandMessage.DocumentAddedSuccsfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(DocumentCommandMessage.AddingDocumentFaild);
            }
        }

        public ICommandResult Execute(EditDocumentCommand command)
        {
            try
            {
                var document = new Document { Id = command.DocumentId, CreationDate = command.CreationDate };
                AddDocument(command, document);
                _documentRepository.Edit(document);
                _unitOfWork.Commit();
                return new SuccessResult(DocumentCommandMessage.DocumentUpdatedSuccsfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(DocumentCommandMessage.UpdatedingDocumentFaild);
            }
        }

        private void AddDocument(IDocumentCommand command, Document document)
        {
            CheckIfDocuemntIsDefault(command, document);
            AddRule(command, document);
            AddAbout(command, document);
            AddGuide(command, document);
            AddInformation(command, document);
            AddSocialMedia(command, document);
        }

        private void CheckIfDocuemntIsDefault(IDocumentCommand command, Document document)
        {
            if (command.StoreId != Guid.Empty)
            {
                var store = _storeRepository.GetById(command.StoreId);
                document.IsDefault = false;
                //document.Stores.Add(store);
            }
            else
            {
                document.IsDefault = true;
            }
        }

        private static void AddInformation(IDocumentCommand command, Document document)
        {
            if (command.InformationCommand != null)
            {
                var information = new Information
                {
                    Body = command.AboutCommand.Body,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                };

                document.Information = information;
            }
        }

        private static void AddGuide(IDocumentCommand command, Document document)
        {
            if (command.GuideCommand == null) return;

            var guide = new Guide
            {
                Body = command.GuideCommand.Body,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            if (command.GuideCommand.PictureCommands != null)
            {
                foreach (var pic in document.Guide.DocumentPictures)
                {
                    document.Guide.DocumentPictures.Add(pic);
                }
            }

            document.Guide = guide;
        }

        private static void AddRule(IDocumentCommand command, Document document)
        {
            if (command.RuleCommand != null)
            {
                var rule = new Rule
                {
                    Body = command.RuleCommand.Body,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now,
                };

                document.Rule = rule;
            }
        }

        private static void AddAbout(IDocumentCommand command, Document document)
        {
            if (command.AboutCommand == null) return;

            var about = new About
            {
                Body = command.AboutCommand.Body,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            if (command.AboutCommand.PictureCommands != null)
            {
                foreach (var pic in document.About.DocumentPictures)
                {
                    document.About.DocumentPictures.Add(pic);
                }
            }

            document.About = about;
        }

        private static void AddSocialMedia(IDocumentCommand command, Document document)
        {
            if (command.SocialMediaCommands == null) return;

            foreach (var socialMedia in command.SocialMedias.Select(item => new SocialMedia
            {
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Url = item.Url,
                SocialMediaOption = new SocialMediaOption
                {
                    CreationDate = DateTime.Now,
                    Creator = "sdf",
                    Name = item.SocialMediaOption.Name,
                }
            }))
            {
                document.AddSocialMedia(socialMedia);
            }
        }
    }
}
