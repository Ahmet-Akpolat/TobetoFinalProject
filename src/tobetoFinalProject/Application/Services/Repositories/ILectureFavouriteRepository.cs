using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILectureFavouriteRepository : IAsyncRepository<LectureFavourite, Guid>, IRepository<LectureFavourite, Guid>
{
}