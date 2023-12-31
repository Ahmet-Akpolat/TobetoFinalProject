using Application.Features.LanguageLevels.Constants;
using Application.Features.LanguageLevels.Constants;
using Application.Features.LanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LanguageLevels.Constants.LanguageLevelsOperationClaims;

namespace Application.Features.LanguageLevels.Commands.Delete;

public class DeleteLanguageLevelCommand : IRequest<DeletedLanguageLevelResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LanguageLevelsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLanguageLevels";

    public class DeleteLanguageLevelCommandHandler : IRequestHandler<DeleteLanguageLevelCommand, DeletedLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly LanguageLevelBusinessRules _languageLevelBusinessRules;

        public DeleteLanguageLevelCommandHandler(IMapper mapper, ILanguageLevelRepository languageLevelRepository,
                                         LanguageLevelBusinessRules languageLevelBusinessRules)
        {
            _mapper = mapper;
            _languageLevelRepository = languageLevelRepository;
            _languageLevelBusinessRules = languageLevelBusinessRules;
        }

        public async Task<DeletedLanguageLevelResponse> Handle(DeleteLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            LanguageLevel? languageLevel = await _languageLevelRepository.GetAsync(predicate: ll => ll.Id == request.Id, cancellationToken: cancellationToken);
            await _languageLevelBusinessRules.LanguageLevelShouldExistWhenSelected(languageLevel);

            await _languageLevelRepository.DeleteAsync(languageLevel!);

            DeletedLanguageLevelResponse response = _mapper.Map<DeletedLanguageLevelResponse>(languageLevel);
            return response;
        }
    }
}