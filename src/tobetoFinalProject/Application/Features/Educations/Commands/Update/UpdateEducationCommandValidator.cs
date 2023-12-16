using FluentValidation;

namespace Application.Features.Educations.Commands.Update;

public class UpdateEducationCommandValidator : AbstractValidator<UpdateEducationCommand>
{
    public UpdateEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EducationStatus).NotEmpty();
        RuleFor(c => c.SchoolName).NotEmpty();
        RuleFor(c => c.Branch).NotEmpty();
        RuleFor(c => c.IsContinued).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.GraduationDate).NotEmpty();
    }
}