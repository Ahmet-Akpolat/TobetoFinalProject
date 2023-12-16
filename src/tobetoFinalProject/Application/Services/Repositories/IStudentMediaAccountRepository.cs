using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentMediaAccountRepository : IAsyncRepository<StudentMediaAccount, Guid>, IRepository<StudentMediaAccount, Guid>
{
}