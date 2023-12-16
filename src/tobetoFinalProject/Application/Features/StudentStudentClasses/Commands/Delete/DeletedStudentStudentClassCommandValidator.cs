using FluentValidation;

namespace Application.Features.StudentStudentClasses.Commands.Delete;

public class DeleteStudentStudentClassCommandValidator : AbstractValidator<DeleteStudentStudentClassCommand>
{
    public DeleteStudentStudentClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}