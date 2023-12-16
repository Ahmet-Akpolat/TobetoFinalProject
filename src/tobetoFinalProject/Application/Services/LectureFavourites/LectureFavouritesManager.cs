using Application.Features.LectureFavourites.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LectureFavourites;

public class LectureFavouritesManager : ILectureFavouritesService
{
    private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
    private readonly LectureFavouriteBusinessRules _lectureFavouriteBusinessRules;

    public LectureFavouritesManager(ILectureFavouriteRepository lectureFavouriteRepository, LectureFavouriteBusinessRules lectureFavouriteBusinessRules)
    {
        _lectureFavouriteRepository = lectureFavouriteRepository;
        _lectureFavouriteBusinessRules = lectureFavouriteBusinessRules;
    }

    public async Task<LectureFavourite?> GetAsync(
        Expression<Func<LectureFavourite, bool>> predicate,
        Func<IQueryable<LectureFavourite>, IIncludableQueryable<LectureFavourite, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LectureFavourite? lectureFavourite = await _lectureFavouriteRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lectureFavourite;
    }

    public async Task<IPaginate<LectureFavourite>?> GetListAsync(
        Expression<Func<LectureFavourite, bool>>? predicate = null,
        Func<IQueryable<LectureFavourite>, IOrderedQueryable<LectureFavourite>>? orderBy = null,
        Func<IQueryable<LectureFavourite>, IIncludableQueryable<LectureFavourite, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LectureFavourite> lectureFavouriteList = await _lectureFavouriteRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lectureFavouriteList;
    }

    public async Task<LectureFavourite> AddAsync(LectureFavourite lectureFavourite)
    {
        LectureFavourite addedLectureFavourite = await _lectureFavouriteRepository.AddAsync(lectureFavourite);

        return addedLectureFavourite;
    }

    public async Task<LectureFavourite> UpdateAsync(LectureFavourite lectureFavourite)
    {
        LectureFavourite updatedLectureFavourite = await _lectureFavouriteRepository.UpdateAsync(lectureFavourite);

        return updatedLectureFavourite;
    }

    public async Task<LectureFavourite> DeleteAsync(LectureFavourite lectureFavourite, bool permanent = false)
    {
        LectureFavourite deletedLectureFavourite = await _lectureFavouriteRepository.DeleteAsync(lectureFavourite);

        return deletedLectureFavourite;
    }
}
