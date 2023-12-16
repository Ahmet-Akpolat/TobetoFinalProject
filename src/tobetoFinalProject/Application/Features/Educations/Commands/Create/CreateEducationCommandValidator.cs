using FluentValidation;

namespace Application.Features.Educations.Commands.Create;

public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
{
    public CreateEducationCommandValidator()
    {
        RuleFor(c => c.EducationStatus).NotEmpty();
        RuleFor(c => c.SchoolName).NotEmpty();
        RuleFor(c => c.Branch).NotEmpty();
        RuleFor(c => c.IsContinued).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.GraduationDate).NotEmpty();
    }
}