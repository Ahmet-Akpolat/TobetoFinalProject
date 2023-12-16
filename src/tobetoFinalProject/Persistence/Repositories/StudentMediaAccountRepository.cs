using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentMediaAccountRepository : EfRepositoryBase<StudentMediaAccount, Guid, BaseDbContext>, IStudentMediaAccountRepository
{
    public StudentMediaAccountRepository(BaseDbContext context) : base(context)
    {
    }
}