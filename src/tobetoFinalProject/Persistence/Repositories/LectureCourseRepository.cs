using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LectureCourseRepository : EfRepositoryBase<LectureCourse, Guid, BaseDbContext>, ILectureCourseRepository
{
    public LectureCourseRepository(BaseDbContext context) : base(context)
    {
    }
}