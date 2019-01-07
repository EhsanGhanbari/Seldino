using AutoMapper;
using Seldino.CrossCutting.Caching;
using Seldino.Domain.DocumentAggregation;
using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.DocumentService
{
    internal class DocumentQueryService : IDocumentQueryService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public DocumentQueryService(IDocumentRepository documentRepository, ICacheManager cacheManager, ILogger logger)
        {
            _documentRepository = documentRepository;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public DocumentQueryResponse GetDefaultDocument(DocumentQueryRequest request)
        {
            var response = new DocumentQueryResponse();

            try
            {
                var defaultDocument = _cacheManager.Retrieve<DocumentDto>("DefaultDocument");

                if (defaultDocument != null)
                {
                    response.Document = defaultDocument;
                }
                else
                {
                    var document = _documentRepository.GetDefaultDocument();

                    if (document != null)
                    {
                        var documentDto = Mapper.Map<Document, DocumentDto>(document);
                        _cacheManager.Store("DefaultDocument", documentDto);
                        response.Document = documentDto;
                    }
                }
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = DocumentQueryMessage.DocumentLoadingFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public DocumentQueryResponse GetDocumentById(DocumentQueryRequest request)
        {
            var response = new DocumentQueryResponse();

            try
            {
                var document = _documentRepository.GetDocumentById(request.DocumentId);
                response.Document = Mapper.Map<Document, DocumentDto>(document);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = DocumentQueryMessage.DocumentLoadingFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public DocumentQueryResponse GetDocumentByStoreId(DocumentQueryRequest request)
        {
            var response = new DocumentQueryResponse();

            try
            {
                var document = _documentRepository.GetDocumentByStoreId(request.StoreId);
                response.Document = Mapper.Map<Document, DocumentDto>(document);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = DocumentQueryMessage.DocumentLoadingFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public SocialMediaQueryResponse GetSocialMediaOptions(SocialMediaQueryRequest request)
        {
            var response = new SocialMediaQueryResponse();

            try
            {
                var socialMediaOptionDto = _cacheManager.Retrieve<IList<SocialMediaOptionDto>>("socialMediaOptions");

                if (socialMediaOptionDto != null)
                {
                    response.SocialMediaOptions = socialMediaOptionDto;
                    return response;
                }

                var socialMediaOptions = _documentRepository.GetAllSocialMediaOptions();
                _cacheManager.Store("socialMediaOptions", socialMediaOptions);
                response.SocialMediaOptions = Mapper.Map<IList<SocialMediaOption>, IList<SocialMediaOptionDto>>(socialMediaOptions);

            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = DocumentQueryMessage.DocumentLoadingFaild;
                _logger.Log(exception);
            }

            return response;
        }
    }
}
