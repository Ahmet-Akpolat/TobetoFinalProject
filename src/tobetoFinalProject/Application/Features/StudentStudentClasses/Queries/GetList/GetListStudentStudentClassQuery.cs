using Application.Features.StudentStudentClasses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentStudentClasses.Constants.StudentStudentClassesOperationClaims;

namespace Application.Features.StudentStudentClasses.Queries.GetList;

public class GetListStudentStudentClassQuery : IRequest<GetListResponse<GetListStudentStudentClassListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentStudentClasses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentStudentClasses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentStudentClassQueryHandler : IRequestHandler<GetListStudentStudentClassQuery, GetListResponse<GetListStudentStudentClassListItemDto>>
    {
        private readonly IStudentStudentClassRepository _studentStudentClassRepository;
        private readonly IMapper _mapper;

        public GetListStudentStudentClassQueryHandler(IStudentStudentClassRepository studentStudentClassRepository, IMapper mapper)
        {
            _studentStudentClassRepository = studentStudentClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentStudentClassListItemDto>> Handle(GetListStudentStudentClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentStudentClass> studentStudentClasses = await _studentStudentClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentStudentClassListItemDto> response = _mapper.Map<GetListResponse<GetListStudentStudentClassListItemDto>>(studentStudentClasses);
            return response;
        }
    }
}