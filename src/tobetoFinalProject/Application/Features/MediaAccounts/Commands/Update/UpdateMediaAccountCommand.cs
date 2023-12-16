using Application.Features.MediaAccounts.Constants;
using Application.Features.MediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.MediaAccounts.Constants.MediaAccountsOperationClaims;

namespace Application.Features.MediaAccounts.Commands.Update;

public class UpdateMediaAccountCommand : IRequest<UpdatedMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }

    public string[] Roles => new[] { Admin, Write, MediaAccountsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMediaAccounts";

    public class UpdateMediaAccountCommandHandler : IRequestHandler<UpdateMediaAccountCommand, UpdatedMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly MediaAccountBusinessRules _mediaAccountBusinessRules;

        public UpdateMediaAccountCommandHandler(IMapper mapper, IMediaAccountRepository mediaAccountRepository,
                                         MediaAccountBusinessRules mediaAccountBusinessRules)
        {
            _mapper = mapper;
            _mediaAccountRepository = mediaAccountRepository;
            _mediaAccountBusinessRules = mediaAccountBusinessRules;
        }

        public async Task<UpdatedMediaAccountResponse> Handle(UpdateMediaAccountCommand request, CancellationToken cancellationToken)
        {
            MediaAccount? mediaAccount = await _mediaAccountRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _mediaAccountBusinessRules.MediaAccountShouldExistWhenSelected(mediaAccount);
            mediaAccount = _mapper.Map(request, mediaAccount);

            await _mediaAccountRepository.UpdateAsync(mediaAccount!);

            UpdatedMediaAccountResponse response = _mapper.Map<UpdatedMediaAccountResponse>(mediaAccount);
            return response;
        }
    }
}