using FluentValidation;

namespace Application.Features.StudentExperiences.Commands.Create;

public class CreateStudentExperienceCommandValidator : AbstractValidator<CreateStudentExperienceCommand>
{
    public CreateStudentExperienceCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExperienceId).NotEmpty();
    }
}