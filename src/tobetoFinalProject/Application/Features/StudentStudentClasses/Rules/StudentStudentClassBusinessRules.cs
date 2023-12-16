using Application.Features.StudentStudentClasses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentStudentClasses.Rules;

public class StudentStudentClassBusinessRules : BaseBusinessRules
{
    private readonly IStudentStudentClassRepository _studentStudentClassRepository;

    public StudentStudentClassBusinessRules(IStudentStudentClassRepository studentStudentClassRepository)
    {
        _studentStudentClassRepository = studentStudentClassRepository;
    }

    public Task StudentStudentClassShouldExistWhenSelected(StudentStudentClass? studentStudentClass)
    {
        if (studentStudentClass == null)
            throw new BusinessException(StudentStudentClassesBusinessMessages.StudentStudentClassNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentStudentClassIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentStudentClass? studentStudentClass = await _studentStudentClassRepository.GetAsync(
            predicate: ssc => ssc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentStudentClassShouldExistWhenSelected(studentStudentClass);
    }
}