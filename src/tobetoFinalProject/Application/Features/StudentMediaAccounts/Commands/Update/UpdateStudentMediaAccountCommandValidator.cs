using FluentValidation;

namespace Application.Features.StudentMediaAccounts.Commands.Update;

public class UpdateStudentMediaAccountCommandValidator : AbstractValidator<UpdateStudentMediaAccountCommand>
{
    public UpdateStudentMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.MediaAccountId).NotEmpty();
    }
}