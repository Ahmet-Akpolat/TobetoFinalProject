using Application.Features.Lectures.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Lectures.Constants.LecturesOperationClaims;

namespace Application.Features.Lectures.Queries.GetList;

public class GetListLectureQuery : IRequest<GetListResponse<GetListLectureListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLectures({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLectures";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLectureQueryHandler : IRequestHandler<GetListLectureQuery, GetListResponse<GetListLectureListItemDto>>
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IMapper _mapper;

        public GetListLectureQueryHandler(ILectureRepository lectureRepository, IMapper mapper)
        {
            _lectureRepository = lectureRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLectureListItemDto>> Handle(GetListLectureQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Lecture> lectures = await _lectureRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLectureListItemDto> response = _mapper.Map<GetListResponse<GetListLectureListItemDto>>(lectures);
            return response;
        }
    }
}