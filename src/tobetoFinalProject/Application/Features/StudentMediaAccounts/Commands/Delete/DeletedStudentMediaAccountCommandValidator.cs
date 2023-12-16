using FluentValidation;

namespace Application.Features.StudentMediaAccounts.Commands.Delete;

public class DeleteStudentMediaAccountCommandValidator : AbstractValidator<DeleteStudentMediaAccountCommand>
{
    public DeleteStudentMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}