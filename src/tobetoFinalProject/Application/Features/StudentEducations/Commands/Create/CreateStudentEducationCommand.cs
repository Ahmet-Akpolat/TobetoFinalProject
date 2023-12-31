using Application.Features.StudentEducations.Constants;
using Application.Features.StudentEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentEducations.Constants.StudentEducationsOperationClaims;

namespace Application.Features.StudentEducations.Commands.Create;

public class CreateStudentEducationCommand : IRequest<CreatedStudentEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid StudentId { get; set; }
    public Guid EducationId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentEducationsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentEducations";

    public class CreateStudentEducationCommandHandler : IRequestHandler<CreateStudentEducationCommand, CreatedStudentEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentEducationRepository _studentEducationRepository;
        private readonly StudentEducationBusinessRules _studentEducationBusinessRules;

        public CreateStudentEducationCommandHandler(IMapper mapper, IStudentEducationRepository studentEducationRepository,
                                         StudentEducationBusinessRules studentEducationBusinessRules)
        {
            _mapper = mapper;
            _studentEducationRepository = studentEducationRepository;
            _studentEducationBusinessRules = studentEducationBusinessRules;
        }

        public async Task<CreatedStudentEducationResponse> Handle(CreateStudentEducationCommand request, CancellationToken cancellationToken)
        {
            StudentEducation studentEducation = _mapper.Map<StudentEducation>(request);

            await _studentEducationRepository.AddAsync(studentEducation);

            CreatedStudentEducationResponse response = _mapper.Map<CreatedStudentEducationResponse>(studentEducation);
            return response;
        }
    }
}