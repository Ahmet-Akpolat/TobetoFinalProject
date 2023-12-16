using Application.Features.StudentMediaAccounts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentMediaAccounts.Constants.StudentMediaAccountsOperationClaims;

namespace Application.Features.StudentMediaAccounts.Queries.GetList;

public class GetListStudentMediaAccountQuery : IRequest<GetListResponse<GetListStudentMediaAccountListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentMediaAccounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentMediaAccounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentMediaAccountQueryHandler : IRequestHandler<GetListStudentMediaAccountQuery, GetListResponse<GetListStudentMediaAccountListItemDto>>
    {
        private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
        private readonly IMapper _mapper;

        public GetListStudentMediaAccountQueryHandler(IStudentMediaAccountRepository studentMediaAccountRepository, IMapper mapper)
        {
            _studentMediaAccountRepository = studentMediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentMediaAccountListItemDto>> Handle(GetListStudentMediaAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentMediaAccount> studentMediaAccounts = await _studentMediaAccountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentMediaAccountListItemDto> response = _mapper.Map<GetListResponse<GetListStudentMediaAccountListItemDto>>(studentMediaAccounts);
            return response;
        }
    }
}