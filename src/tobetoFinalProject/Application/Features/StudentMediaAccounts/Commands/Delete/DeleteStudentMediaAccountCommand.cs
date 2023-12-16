using Application.Features.StudentMediaAccounts.Constants;
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

namespace Application.Features.StudentMediaAccounts.Commands.Delete;

public class DeleteStudentMediaAccountCommand : IRequest<DeletedStudentMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentMediaAccountsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentMediaAccounts";

    public class DeleteStudentMediaAccountCommandHandler : IRequestHandler<DeleteStudentMediaAccountCommand, DeletedStudentMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
        private readonly StudentMediaAccountBusinessRules _studentMediaAccountBusinessRules;

        public DeleteStudentMediaAccountCommandHandler(IMapper mapper, IStudentMediaAccountRepository studentMediaAccountRepository,
                                         StudentMediaAccountBusinessRules studentMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _studentMediaAccountRepository = studentMediaAccountRepository;
            _studentMediaAccountBusinessRules = studentMediaAccountBusinessRules;
        }

        public async Task<DeletedStudentMediaAccountResponse> Handle(DeleteStudentMediaAccountCommand request, CancellationToken cancellationToken)
        {
            StudentMediaAccount? studentMediaAccount = await _studentMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _studentMediaAccountBusinessRules.StudentMediaAccountShouldExistWhenSelected(studentMediaAccount);

            await _studentMediaAccountRepository.DeleteAsync(studentMediaAccount!);

            DeletedStudentMediaAccountResponse response = _mapper.Map<DeletedStudentMediaAccountResponse>(studentMediaAccount);
            return response;
        }
    }
}