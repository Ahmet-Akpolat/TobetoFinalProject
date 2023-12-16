using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMediaAccountRepository : IAsyncRepository<MediaAccount, Guid>, IRepository<MediaAccount, Guid>
{
}