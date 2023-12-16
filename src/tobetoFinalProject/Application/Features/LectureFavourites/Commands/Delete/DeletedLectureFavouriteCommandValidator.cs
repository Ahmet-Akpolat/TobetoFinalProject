using FluentValidation;

namespace Application.Features.LectureFavourites.Commands.Delete;

public class DeleteLectureFavouriteCommandValidator : AbstractValidator<DeleteLectureFavouriteCommand>
{
    public DeleteLectureFavouriteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}