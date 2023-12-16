using FluentValidation;

namespace Application.Features.LectureFavourites.Commands.Update;

public class UpdateLectureFavouriteCommandValidator : AbstractValidator<UpdateLectureFavouriteCommand>
{
    public UpdateLectureFavouriteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LectureId).NotEmpty();
    }
}