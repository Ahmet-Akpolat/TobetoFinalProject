using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LectureFavourites;

public interface ILectureFavouritesService
{
    Task<LectureFavourite?> GetAsync(
        Expression<Func<LectureFavourite, bool>> predicate,
        Func<IQueryable<LectureFavourite>, IIncludableQueryable<LectureFavourite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LectureFavourite>?> GetListAsync(
        Expression<Func<LectureFavourite, bool>>? predicate = null,
        Func<IQueryable<LectureFavourite>, IOrderedQueryable<LectureFavourite>>? orderBy = null,
        Func<IQueryable<LectureFavourite>, IIncludableQueryable<LectureFavourite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LectureFavourite> AddAsync(LectureFavourite lectureFavourite);
    Task<LectureFavourite> UpdateAsync(LectureFavourite lectureFavourite);
    Task<LectureFavourite> DeleteAsync(LectureFavourite lectureFavourite, bool permanent = false);
}
