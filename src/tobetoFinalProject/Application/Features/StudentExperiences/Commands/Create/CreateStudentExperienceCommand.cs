using Application.Features.StudentExperiences.Constants;
using Application.Features.StudentExperiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentExperiences.Constants.StudentExperiencesOperationClaims;

namespace Application.Features.StudentExperiences.Commands.Create;

public class CreateStudentExperienceCommand : IRequest<CreatedStudentExperienceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid StudentId { get; set; }
    public Guid ExperienceId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentExperiencesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentExperiences";

    public class CreateStudentExperienceCommandHandler : IRequestHandler<CreateStudentExperienceCommand, CreatedStudentExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExperienceRepository _studentExperienceRepository;
        private readonly StudentExperienceBusinessRules _studentExperienceBusinessRules;

        public CreateStudentExperienceCommandHandler(IMapper mapper, IStudentExperienceRepository studentExperienceRepository,
                                         StudentExperienceBusinessRules studentExperienceBusinessRules)
        {
            _mapper = mapper;
            _studentExperienceRepository = studentExperienceRepository;
            _studentExperienceBusinessRules = studentExperienceBusinessRules;
        }

        public async Task<CreatedStudentExperienceResponse> Handle(CreateStudentExperienceCommand request, CancellationToken cancellationToken)
        {
            StudentExperience studentExperience = _mapper.Map<StudentExperience>(request);

            await _studentExperienceRepository.AddAsync(studentExperience);

            CreatedStudentExperienceResponse response = _mapper.Map<CreatedStudentExperienceResponse>(studentExperience);
            return response;
        }
    }
}