using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentStudentClassRepository : EfRepositoryBase<StudentStudentClass, Guid, BaseDbContext>, IStudentStudentClassRepository
{
    public StudentStudentClassRepository(BaseDbContext context) : base(context)
    {
    }
}