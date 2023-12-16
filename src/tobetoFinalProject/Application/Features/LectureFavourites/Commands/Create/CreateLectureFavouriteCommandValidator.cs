using FluentValidation;

namespace Application.Features.LectureFavourites.Commands.Create;

public class CreateLectureFavouriteCommandValidator : AbstractValidator<CreateLectureFavouriteCommand>
{
    public CreateLectureFavouriteCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LectureId).NotEmpty();
    }
}