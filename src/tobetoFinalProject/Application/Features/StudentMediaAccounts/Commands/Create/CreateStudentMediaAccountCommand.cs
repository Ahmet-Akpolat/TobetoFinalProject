using Application.Features.StudentMediaAccounts.Constants;
using Application.Features.StudentMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentMediaAccounts.Constants.StudentMediaAccountsOperationClaims;

namespace Application.Features.StudentMediaAccounts.Commands.Create;

public class CreateStudentMediaAccountCommand : IRequest<CreatedStudentMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentMediaAccountsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentMediaAccounts";

    public class CreateStudentMediaAccountCommandHandler : IRequestHandler<CreateStudentMediaAccountCommand, CreatedStudentMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
        private readonly StudentMediaAccountBusinessRules _studentMediaAccountBusinessRules;

        public CreateStudentMediaAccountCommandHandler(IMapper mapper, IStudentMediaAccountRepository studentMediaAccountRepository,
                                         StudentMediaAccountBusinessRules studentMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _studentMediaAccountRepository = studentMediaAccountRepository;
            _studentMediaAccountBusinessRules = studentMediaAccountBusinessRules;
        }

        public async Task<CreatedStudentMediaAccountResponse> Handle(CreateStudentMediaAccountCommand request, CancellationToken cancellationToken)
        {
            StudentMediaAccount studentMediaAccount = _mapper.Map<StudentMediaAccount>(request);

            await _studentMediaAccountRepository.AddAsync(studentMediaAccount);

            CreatedStudentMediaAccountResponse response = _mapper.Map<CreatedStudentMediaAccountResponse>(studentMediaAccount);
            return response;
        }
    }
}