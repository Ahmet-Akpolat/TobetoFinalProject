using Application.Features.Educations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Educations.Constants.EducationsOperationClaims;

namespace Application.Features.Educations.Queries.GetList;

public class GetListEducationQuery : IRequest<GetListResponse<GetListEducationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListEducations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetEducations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEducationQueryHandler : IRequestHandler<GetListEducationQuery, GetListResponse<GetListEducationListItemDto>>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public GetListEducationQueryHandler(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationListItemDto>> Handle(GetListEducationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Education> educations = await _educationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationListItemDto> response = _mapper.Map<GetListResponse<GetListEducationListItemDto>>(educations);
            return response;
        }
    }
}