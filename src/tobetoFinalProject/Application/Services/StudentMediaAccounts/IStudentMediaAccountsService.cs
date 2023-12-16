using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentMediaAccounts;

public interface IStudentMediaAccountsService
{
    Task<StudentMediaAccount?> GetAsync(
        Expression<Func<StudentMediaAccount, bool>> predicate,
        Func<IQueryable<StudentMediaAccount>, IIncludableQueryable<StudentMediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentMediaAccount>?> GetListAsync(
        Expression<Func<StudentMediaAccount, bool>>? predicate = null,
        Func<IQueryable<StudentMediaAccount>, IOrderedQueryable<StudentMediaAccount>>? orderBy = null,
        Func<IQueryable<StudentMediaAccount>, IIncludableQueryable<StudentMediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentMediaAccount> AddAsync(StudentMediaAccount studentMediaAccount);
    Task<StudentMediaAccount> UpdateAsync(StudentMediaAccount studentMediaAccount);
    Task<StudentMediaAccount> DeleteAsync(StudentMediaAccount studentMediaAccount, bool permanent = false);
}
