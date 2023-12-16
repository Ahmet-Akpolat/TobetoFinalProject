using FluentValidation;

namespace Application.Features.MediaAccounts.Commands.Update;

public class UpdateMediaAccountCommandValidator : AbstractValidator<UpdateMediaAccountCommand>
{
    public UpdateMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.MediaUrl).NotEmpty();
    }
}