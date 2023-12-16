using Application.Features.MediaAccounts.Constants;
using Application.Features.MediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MediaAccounts.Constants.MediaAccountsOperationClaims;

namespace Application.Features.MediaAccounts.Queries.GetById;

public class GetByIdMediaAccountQuery : IRequest<GetByIdMediaAccountResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdMediaAccountQueryHandler : IRequestHandler<GetByIdMediaAccountQuery, GetByIdMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly MediaAccountBusinessRules _mediaAccountBusinessRules;

        public GetByIdMediaAccountQueryHandler(IMapper mapper, IMediaAccountRepository mediaAccountRepository, MediaAccountBusinessRules mediaAccountBusinessRules)
        {
            _mapper = mapper;
            _mediaAccountRepository = mediaAccountRepository;
            _mediaAccountBusinessRules = mediaAccountBusinessRules;
        }

        public async Task<GetByIdMediaAccountResponse> Handle(GetByIdMediaAccountQuery request, CancellationToken cancellationToken)
        {
            MediaAccount? mediaAccount = await _mediaAccountRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _mediaAccountBusinessRules.MediaAccountShouldExistWhenSelected(mediaAccount);

            GetByIdMediaAccountResponse response = _mapper.Map<GetByIdMediaAccountResponse>(mediaAccount);
            return response;
        }
    }
}