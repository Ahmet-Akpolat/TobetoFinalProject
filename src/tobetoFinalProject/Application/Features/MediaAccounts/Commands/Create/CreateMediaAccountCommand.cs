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

namespace Application.Features.MediaAccounts.Commands.Create;

public class CreateMediaAccountCommand : IRequest<CreatedMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string MediaUrl { get; set; }

    public string[] Roles => new[] { Admin, Write, MediaAccountsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMediaAccounts";

    public class CreateMediaAccountCommandHandler : IRequestHandler<CreateMediaAccountCommand, CreatedMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly MediaAccountBusinessRules _mediaAccountBusinessRules;

        public CreateMediaAccountCommandHandler(IMapper mapper, IMediaAccountRepository mediaAccountRepository,
                                         MediaAccountBusinessRules mediaAccountBusinessRules)
        {
            _mapper = mapper;
            _mediaAccountRepository = mediaAccountRepository;
            _mediaAccountBusinessRules = mediaAccountBusinessRules;
        }

        public async Task<CreatedMediaAccountResponse> Handle(CreateMediaAccountCommand request, CancellationToken cancellationToken)
        {
            MediaAccount mediaAccount = _mapper.Map<MediaAccount>(request);

            await _mediaAccountRepository.AddAsync(mediaAccount);

            CreatedMediaAccountResponse response = _mapper.Map<CreatedMediaAccountResponse>(mediaAccount);
            return response;
        }
    }
}