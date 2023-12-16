using FluentValidation;

namespace Application.Features.MediaAccounts.Commands.Create;

public class CreateMediaAccountCommandValidator : AbstractValidator<CreateMediaAccountCommand>
{
    public CreateMediaAccountCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MediaUrl).NotEmpty();
    }
}