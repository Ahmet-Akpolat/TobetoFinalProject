using Application.Features.StudentStudentClasses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentStudentClasses;

public class StudentStudentClassesManager : IStudentStudentClassesService
{
    private readonly IStudentStudentClassRepository _studentStudentClassRepository;
    private readonly StudentStudentClassBusinessRules _studentStudentClassBusinessRules;

    public StudentStudentClassesManager(IStudentStudentClassRepository studentStudentClassRepository, StudentStudentClassBusinessRules studentStudentClassBusinessRules)
    {
        _studentStudentClassRepository = studentStudentClassRepository;
        _studentStudentClassBusinessRules = studentStudentClassBusinessRules;
    }

    public async Task<StudentStudentClass?> GetAsync(
        Expression<Func<StudentStudentClass, bool>> predicate,
        Func<IQueryable<StudentStudentClass>, IIncludableQueryable<StudentStudentClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentStudentClass? studentStudentClass = await _studentStudentClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentStudentClass;
    }

    public async Task<IPaginate<StudentStudentClass>?> GetListAsync(
        Expression<Func<StudentStudentClass, bool>>? predicate = null,
        Func<IQueryable<StudentStudentClass>, IOrderedQueryable<StudentStudentClass>>? orderBy = null,
        Func<IQueryable<StudentStudentClass>, IIncludableQueryable<StudentStudentClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentStudentClass> studentStudentClassList = await _studentStudentClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentStudentClassList;
    }

    public async Task<StudentStudentClass> AddAsync(StudentStudentClass studentStudentClass)
    {
        StudentStudentClass addedStudentStudentClass = await _studentStudentClassRepository.AddAsync(studentStudentClass);

        return addedStudentStudentClass;
    }

    public async Task<StudentStudentClass> UpdateAsync(StudentStudentClass studentStudentClass)
    {
        StudentStudentClass updatedStudentStudentClass = await _studentStudentClassRepository.UpdateAsync(studentStudentClass);

        return updatedStudentStudentClass;
    }

    public async Task<StudentStudentClass> DeleteAsync(StudentStudentClass studentStudentClass, bool permanent = false)
    {
        StudentStudentClass deletedStudentStudentClass = await _studentStudentClassRepository.DeleteAsync(studentStudentClass);

        return deletedStudentStudentClass;
    }
}
