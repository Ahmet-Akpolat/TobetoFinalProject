using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExperienceRepository : EfRepositoryBase<Experience, Guid, BaseDbContext>, IExperienceRepository
{
    public ExperienceRepository(BaseDbContext context) : base(context)
    {
    }
}