using FluentValidation;

namespace Application.Features.MediaAccounts.Commands.Delete;

public class DeleteMediaAccountCommandValidator : AbstractValidator<DeleteMediaAccountCommand>
{
    public DeleteMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}