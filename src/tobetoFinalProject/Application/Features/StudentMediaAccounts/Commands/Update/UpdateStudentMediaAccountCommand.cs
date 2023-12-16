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

namespace Application.Features.StudentMediaAccounts.Commands.Update;

public class UpdateStudentMediaAccountCommand : IRequest<UpdatedStudentMediaAccountResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentMediaAccountsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentMediaAccounts";

    public class UpdateStudentMediaAccountCommandHandler : IRequestHandler<UpdateStudentMediaAccountCommand, UpdatedStudentMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
        private readonly StudentMediaAccountBusinessRules _studentMediaAccountBusinessRules;

        public UpdateStudentMediaAccountCommandHandler(IMapper mapper, IStudentMediaAccountRepository studentMediaAccountRepository,
                                         StudentMediaAccountBusinessRules studentMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _studentMediaAccountRepository = studentMediaAccountRepository;
            _studentMediaAccountBusinessRules = studentMediaAccountBusinessRules;
        }

        public async Task<UpdatedStudentMediaAccountResponse> Handle(UpdateStudentMediaAccountCommand request, CancellationToken cancellationToken)
        {
            StudentMediaAccount? studentMediaAccount = await _studentMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _studentMediaAccountBusinessRules.StudentMediaAccountShouldExistWhenSelected(studentMediaAccount);
            studentMediaAccount = _mapper.Map(request, studentMediaAccount);

            await _studentMediaAccountRepository.UpdateAsync(studentMediaAccount!);

            UpdatedStudentMediaAccountResponse response = _mapper.Map<UpdatedStudentMediaAccountResponse>(studentMediaAccount);
            return response;
        }
    }
}