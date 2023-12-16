using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentStudentClasses;

public interface IStudentStudentClassesService
{
    Task<StudentStudentClass?> GetAsync(
        Expression<Func<StudentStudentClass, bool>> predicate,
        Func<IQueryable<StudentStudentClass>, IIncludableQueryable<StudentStudentClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentStudentClass>?> GetListAsync(
        Expression<Func<StudentStudentClass, bool>>? predicate = null,
        Func<IQueryable<StudentStudentClass>, IOrderedQueryable<StudentStudentClass>>? orderBy = null,
        Func<IQueryable<StudentStudentClass>, IIncludableQueryable<StudentStudentClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentStudentClass> AddAsync(StudentStudentClass studentStudentClass);
    Task<StudentStudentClass> UpdateAsync(StudentStudentClass studentStudentClass);
    Task<StudentStudentClass> DeleteAsync(StudentStudentClass studentStudentClass, bool permanent = false);
}
