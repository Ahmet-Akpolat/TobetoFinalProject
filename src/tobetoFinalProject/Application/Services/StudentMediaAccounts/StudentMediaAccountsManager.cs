using Application.Features.StudentMediaAccounts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentMediaAccounts;

public class StudentMediaAccountsManager : IStudentMediaAccountsService
{
    private readonly IStudentMediaAccountRepository _studentMediaAccountRepository;
    private readonly StudentMediaAccountBusinessRules _studentMediaAccountBusinessRules;

    public StudentMediaAccountsManager(IStudentMediaAccountRepository studentMediaAccountRepository, StudentMediaAccountBusinessRules studentMediaAccountBusinessRules)
    {
        _studentMediaAccountRepository = studentMediaAccountRepository;
        _studentMediaAccountBusinessRules = studentMediaAccountBusinessRules;
    }

    public async Task<StudentMediaAccount?> GetAsync(
        Expression<Func<StudentMediaAccount, bool>> predicate,
        Func<IQueryable<StudentMediaAccount>, IIncludableQueryable<StudentMediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentMediaAccount? studentMediaAccount = await _studentMediaAccountRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentMediaAccount;
    }

    public async Task<IPaginate<StudentMediaAccount>?> GetListAsync(
        Expression<Func<StudentMediaAccount, bool>>? predicate = null,
        Func<IQueryable<StudentMediaAccount>, IOrderedQueryable<StudentMediaAccount>>? orderBy = null,
        Func<IQueryable<StudentMediaAccount>, IIncludableQueryable<StudentMediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentMediaAccount> studentMediaAccountList = await _studentMediaAccountRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentMediaAccountList;
    }

    public async Task<StudentMediaAccount> AddAsync(StudentMediaAccount studentMediaAccount)
    {
        StudentMediaAccount addedStudentMediaAccount = await _studentMediaAccountRepository.AddAsync(studentMediaAccount);

        return addedStudentMediaAccount;
    }

    public async Task<StudentMediaAccount> UpdateAsync(StudentMediaAccount studentMediaAccount)
    {
        StudentMediaAccount updatedStudentMediaAccount = await _studentMediaAccountRepository.UpdateAsync(studentMediaAccount);

        return updatedStudentMediaAccount;
    }

    public async Task<StudentMediaAccount> DeleteAsync(StudentMediaAccount studentMediaAccount, bool permanent = false)
    {
        StudentMediaAccount deletedStudentMediaAccount = await _studentMediaAccountRepository.DeleteAsync(studentMediaAccount);

        return deletedStudentMediaAccount;
    }
}
