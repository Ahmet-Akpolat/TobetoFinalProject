using Application.Features.StudentStudentClasses.Constants;
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

namespace Application.Features.StudentStudentClasses.Commands.Delete;

public class DeleteStudentStudentClassCommand : IRequest<DeletedStudentStudentClassResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentStudentClassesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentStudentClasses";

    public class DeleteStudentStudentClassCommandHandler : IRequestHandler<DeleteStudentStudentClassCommand, DeletedStudentStudentClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentStudentClassRepository _studentStudentClassRepository;
        private readonly StudentStudentClassBusinessRules _studentStudentClassBusinessRules;

        public DeleteStudentStudentClassCommandHandler(IMapper mapper, IStudentStudentClassRepository studentStudentClassRepository,
                                         StudentStudentClassBusinessRules studentStudentClassBusinessRules)
        {
            _mapper = mapper;
            _studentStudentClassRepository = studentStudentClassRepository;
            _studentStudentClassBusinessRules = studentStudentClassBusinessRules;
        }

        public async Task<DeletedStudentStudentClassResponse> Handle(DeleteStudentStudentClassCommand request, CancellationToken cancellationToken)
        {
            StudentStudentClass? studentStudentClass = await _studentStudentClassRepository.GetAsync(predicate: ssc => ssc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentStudentClassBusinessRules.StudentStudentClassShouldExistWhenSelected(studentStudentClass);

            await _studentStudentClassRepository.DeleteAsync(studentStudentClass!);

            DeletedStudentStudentClassResponse response = _mapper.Map<DeletedStudentStudentClassResponse>(studentStudentClass);
            return response;
        }
    }
}