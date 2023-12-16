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

namespace Application.Features.StudentStudentClasses.Commands.Update;

public class UpdateStudentStudentClassCommand : IRequest<UpdatedStudentStudentClassResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid StudentClassId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentStudentClassesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentStudentClasses";

    public class UpdateStudentStudentClassCommandHandler : IRequestHandler<UpdateStudentStudentClassCommand, UpdatedStudentStudentClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentStudentClassRepository _studentStudentClassRepository;
        private readonly StudentStudentClassBusinessRules _studentStudentClassBusinessRules;

        public UpdateStudentStudentClassCommandHandler(IMapper mapper, IStudentStudentClassRepository studentStudentClassRepository,
                                         StudentStudentClassBusinessRules studentStudentClassBusinessRules)
        {
            _mapper = mapper;
            _studentStudentClassRepository = studentStudentClassRepository;
            _studentStudentClassBusinessRules = studentStudentClassBusinessRules;
        }

        public async Task<UpdatedStudentStudentClassResponse> Handle(UpdateStudentStudentClassCommand request, CancellationToken cancellationToken)
        {
            StudentStudentClass? studentStudentClass = await _studentStudentClassRepository.GetAsync(predicate: ssc => ssc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentStudentClassBusinessRules.StudentStudentClassShouldExistWhenSelected(studentStudentClass);
            studentStudentClass = _mapper.Map(request, studentStudentClass);

            await _studentStudentClassRepository.UpdateAsync(studentStudentClass!);

            UpdatedStudentStudentClassResponse response = _mapper.Map<UpdatedStudentStudentClassResponse>(studentStudentClass);
            return response;
        }
    }
}