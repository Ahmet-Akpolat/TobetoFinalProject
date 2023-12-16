using FluentValidation;

namespace Application.Features.StudentStudentClasses.Commands.Create;

public class CreateStudentStudentClassCommandValidator : AbstractValidator<CreateStudentStudentClassCommand>
{
    public CreateStudentStudentClassCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.StudentClassId).NotEmpty();
    }
}