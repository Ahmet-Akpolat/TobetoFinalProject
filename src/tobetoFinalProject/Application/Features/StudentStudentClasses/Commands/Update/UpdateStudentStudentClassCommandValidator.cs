using FluentValidation;

namespace Application.Features.StudentStudentClasses.Commands.Update;

public class UpdateStudentStudentClassCommandValidator : AbstractValidator<UpdateStudentStudentClassCommand>
{
    public UpdateStudentStudentClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.StudentClassId).NotEmpty();
    }
}