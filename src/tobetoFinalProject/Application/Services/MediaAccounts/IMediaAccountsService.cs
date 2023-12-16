using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MediaAccounts;

public interface IMediaAccountsService
{
    Task<MediaAccount?> GetAsync(
        Expression<Func<MediaAccount, bool>> predicate,
        Func<IQueryable<MediaAccount>, IIncludableQueryable<MediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MediaAccount>?> GetListAsync(
        Expression<Func<MediaAccount, bool>>? predicate = null,
        Func<IQueryable<MediaAccount>, IOrderedQueryable<MediaAccount>>? orderBy = null,
        Func<IQueryable<MediaAccount>, IIncludableQueryable<MediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MediaAccount> AddAsync(MediaAccount mediaAccount);
    Task<MediaAccount> UpdateAsync(MediaAccount mediaAccount);
    Task<MediaAccount> DeleteAsync(MediaAccount mediaAccount, bool permanent = false);
}
