using Application.Features.LectureFavourites.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.LectureFavourites.Constants.LectureFavouritesOperationClaims;

namespace Application.Features.LectureFavourites.Queries.GetList;

public class GetListLectureFavouriteQuery : IRequest<GetListResponse<GetListLectureFavouriteListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLectureFavourites({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLectureFavourites";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLectureFavouriteQueryHandler : IRequestHandler<GetListLectureFavouriteQuery, GetListResponse<GetListLectureFavouriteListItemDto>>
    {
        private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
        private readonly IMapper _mapper;

        public GetListLectureFavouriteQueryHandler(ILectureFavouriteRepository lectureFavouriteRepository, IMapper mapper)
        {
            _lectureFavouriteRepository = lectureFavouriteRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLectureFavouriteListItemDto>> Handle(GetListLectureFavouriteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LectureFavourite> lectureFavourites = await _lectureFavouriteRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLectureFavouriteListItemDto> response = _mapper.Map<GetListResponse<GetListLectureFavouriteListItemDto>>(lectureFavourites);
            return response;
        }
    }
}