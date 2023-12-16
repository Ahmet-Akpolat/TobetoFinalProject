using Application.Features.CourseContents.Constants;
using Application.Features.CourseContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CourseContents.Constants.CourseContentsOperationClaims;

namespace Application.Features.CourseContents.Commands.Create;

public class CreateCourseContentCommand : IRequest<CreatedCourseContentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CourseId { get; set; }
    public Guid ContentId { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseContentsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseContents";

    public class CreateCourseContentCommandHandler : IRequestHandler<CreateCourseContentCommand, CreatedCourseContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly CourseContentBusinessRules _courseContentBusinessRules;

        public CreateCourseContentCommandHandler(IMapper mapper, ICourseContentRepository courseContentRepository,
                                         CourseContentBusinessRules courseContentBusinessRules)
        {
            _mapper = mapper;
            _courseContentRepository = courseContentRepository;
            _courseContentBusinessRules = courseContentBusinessRules;
        }

        public async Task<CreatedCourseContentResponse> Handle(CreateCourseContentCommand request, CancellationToken cancellationToken)
        {
            CourseContent courseContent = _mapper.Map<CourseContent>(request);

            await _courseContentRepository.AddAsync(courseContent);

            CreatedCourseContentResponse response = _mapper.Map<CreatedCourseContentResponse>(courseContent);
            return response;
        }
    }
}