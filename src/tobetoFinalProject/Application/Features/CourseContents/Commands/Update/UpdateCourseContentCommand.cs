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

namespace Application.Features.CourseContents.Commands.Update;

public class UpdateCourseContentCommand : IRequest<UpdatedCourseContentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ContentId { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseContentsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseContents";

    public class UpdateCourseContentCommandHandler : IRequestHandler<UpdateCourseContentCommand, UpdatedCourseContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly CourseContentBusinessRules _courseContentBusinessRules;

        public UpdateCourseContentCommandHandler(IMapper mapper, ICourseContentRepository courseContentRepository,
                                         CourseContentBusinessRules courseContentBusinessRules)
        {
            _mapper = mapper;
            _courseContentRepository = courseContentRepository;
            _courseContentBusinessRules = courseContentBusinessRules;
        }

        public async Task<UpdatedCourseContentResponse> Handle(UpdateCourseContentCommand request, CancellationToken cancellationToken)
        {
            CourseContent? courseContent = await _courseContentRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseContentBusinessRules.CourseContentShouldExistWhenSelected(courseContent);
            courseContent = _mapper.Map(request, courseContent);

            await _courseContentRepository.UpdateAsync(courseContent!);

            UpdatedCourseContentResponse response = _mapper.Map<UpdatedCourseContentResponse>(courseContent);
            return response;
        }
    }
}