using Application.Features.StudentStudentClasses.Constants;
using Application.Features.StudentStudentClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentStudentClasses.Constants.StudentStudentClassesOperationClaims;

namespace Application.Features.StudentStudentClasses.Commands.Create;

public class CreateStudentStudentClassCommand : IRequest<CreatedStudentStudentClassResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid StudentId { get; set; }
    public Guid StudentClassId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentStudentClassesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentStudentClasses";

    public class CreateStudentStudentClassCommandHandler : IRequestHandler<CreateStudentStudentClassCommand, CreatedStudentStudentClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentStudentClassRepository _studentStudentClassRepository;
        private readonly StudentStudentClassBusinessRules _studentStudentClassBusinessRules;

        public CreateStudentStudentClassCommandHandler(IMapper mapper, IStudentStudentClassRepository studentStudentClassRepository,
                                         StudentStudentClassBusinessRules studentStudentClassBusinessRules)
        {
            _mapper = mapper;
            _studentStudentClassRepository = studentStudentClassRepository;
            _studentStudentClassBusinessRules = studentStudentClassBusinessRules;
        }

        public async Task<CreatedStudentStudentClassResponse> Handle(CreateStudentStudentClassCommand request, CancellationToken cancellationToken)
        {
            StudentStudentClass studentStudentClass = _mapper.Map<StudentStudentClass>(request);

            await _studentStudentClassRepository.AddAsync(studentStudentClass);

            CreatedStudentStudentClassResponse response = _mapper.Map<CreatedStudentStudentClassResponse>(studentStudentClass);
            return response;
        }
    }
}