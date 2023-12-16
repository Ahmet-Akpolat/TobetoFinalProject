using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentStudentClassRepository : IAsyncRepository<StudentStudentClass, Guid>, IRepository<StudentStudentClass, Guid>
{
}