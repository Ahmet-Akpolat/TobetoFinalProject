using Application.Features.StudentMediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentMediaAccounts.Rules;

public class StudentMediaAccountBusinessRules : BaseBusinessRules
{
    private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;

    public StudentMediaAccountBusinessRules(IStudentMediaAccountRepository studentMediaAccountRepository)
    {
        _studentMediaAccountRepository = studentMediaAccountRepository;
    }

    public Task StudentMediaAccountShouldExistWhenSelected(StudentMediaAccount? studentMediaAccount)
    {
        if (studentMediaAccount == null)
            throw new BusinessException(StudentMediaAccountsBusinessMessages.StudentMediaAccountNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentMediaAccountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentMediaAccount? studentMediaAccount = await _studentMediaAccountRepository.GetAsync(
            predicate: sma => sma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentMediaAccountShouldExistWhenSelected(studentMediaAccount);
    }
}