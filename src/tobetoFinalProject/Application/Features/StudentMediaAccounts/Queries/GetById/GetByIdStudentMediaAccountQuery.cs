using Application.Features.StudentMediaAccounts.Constants;
using Application.Features.StudentMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentMediaAccounts.Constants.StudentMediaAccountsOperationClaims;

namespace Application.Features.StudentMediaAccounts.Queries.GetById;

public class GetByIdStudentMediaAccountQuery : IRequest<GetByIdStudentMediaAccountResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentMediaAccountQueryHandler : IRequestHandler<GetByIdStudentMediaAccountQuery, GetByIdStudentMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
        private readonly StudentMediaAccountBusinessRules _studentMediaAccountBusinessRules;

        public GetByIdStudentMediaAccountQueryHandler(IMapper mapper, IStudentMediaAccountRepository studentMediaAccountRepository, StudentMediaAccountBusinessRules studentMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _studentMediaAccountRepository = studentMediaAccountRepository;
            _studentMediaAccountBusinessRules = studentMediaAccountBusinessRules;
        }

        public async Task<GetByIdStudentMediaAccountResponse> Handle(GetByIdStudentMediaAccountQuery request, CancellationToken cancellationToken)
        {
            StudentMediaAccount? studentMediaAccount = await _studentMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _studentMediaAccountBusinessRules.StudentMediaAccountShouldExistWhenSelected(studentMediaAccount);

            GetByIdStudentMediaAccountResponse response = _mapper.Map<GetByIdStudentMediaAccountResponse>(studentMediaAccount);
            return response;
        }
    }
}