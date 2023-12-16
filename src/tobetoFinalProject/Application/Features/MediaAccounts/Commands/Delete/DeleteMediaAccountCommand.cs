using Application.Features.MediaAccounts.Constants;
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

namespace Application.Features.MediaAccounts.Commands.Delete;

public class DeleteMediaAccountCommand : IRequest<DeletedMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, MediaAccountsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMediaAccounts";

    public class DeleteMediaAccountCommandHandler : IRequestHandler<DeleteMediaAccountCommand, DeletedMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly MediaAccountBusinessRules _mediaAccountBusinessRules;

        public DeleteMediaAccountCommandHandler(IMapper mapper, IMediaAccountRepository mediaAccountRepository,
                                         MediaAccountBusinessRules mediaAccountBusinessRules)
        {
            _mapper = mapper;
            _mediaAccountRepository = mediaAccountRepository;
            _mediaAccountBusinessRules = mediaAccountBusinessRules;
        }

        public async Task<DeletedMediaAccountResponse> Handle(DeleteMediaAccountCommand request, CancellationToken cancellationToken)
        {
            MediaAccount? mediaAccount = await _mediaAccountRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _mediaAccountBusinessRules.MediaAccountShouldExistWhenSelected(mediaAccount);

            await _mediaAccountRepository.DeleteAsync(mediaAccount!);

            DeletedMediaAccountResponse response = _mapper.Map<DeletedMediaAccountResponse>(mediaAccount);
            return response;
        }
    }
}