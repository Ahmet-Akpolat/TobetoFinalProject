using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LectureFavouriteRepository : EfRepositoryBase<LectureFavourite, Guid, BaseDbContext>, ILectureFavouriteRepository
{
    public LectureFavouriteRepository(BaseDbContext context) : base(context)
    {
    }
}