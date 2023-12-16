using Application.Features.MediaAccounts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.MediaAccounts.Constants.MediaAccountsOperationClaims;

namespace Application.Features.MediaAccounts.Queries.GetList;

public class GetListMediaAccountQuery : IRequest<GetListResponse<GetListMediaAccountListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListMediaAccounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetMediaAccounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMediaAccountQueryHandler : IRequestHandler<GetListMediaAccountQuery, GetListResponse<GetListMediaAccountListItemDto>>
    {
        private readonly IMediaAccountRepository _mediaAccountRepository;
        private readonly IMapper _mapper;

        public GetListMediaAccountQueryHandler(IMediaAccountRepository mediaAccountRepository, IMapper mapper)
        {
            _mediaAccountRepository = mediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMediaAccountListItemDto>> Handle(GetListMediaAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MediaAccount> mediaAccounts = await _mediaAccountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMediaAccountListItemDto> response = _mapper.Map<GetListResponse<GetListMediaAccountListItemDto>>(mediaAccounts);
            return response;
        }
    }
}