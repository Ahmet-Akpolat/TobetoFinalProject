using FluentValidation;

namespace Application.Features.StudentMediaAccounts.Commands.Create;

public class CreateStudentMediaAccountCommandValidator : AbstractValidator<CreateStudentMediaAccountCommand>
{
    public CreateStudentMediaAccountCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.MediaAccountId).NotEmpty();
    }
}