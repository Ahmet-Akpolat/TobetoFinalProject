using FluentValidation;

namespace Application.Features.StudentExperiences.Commands.Update;

public class UpdateStudentExperienceCommandValidator : AbstractValidator<UpdateStudentExperienceCommand>
{
    public UpdateStudentExperienceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExperienceId).NotEmpty();
    }
}