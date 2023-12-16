using FluentValidation;

namespace Application.Features.StudentEducations.Commands.Update;

public class UpdateStudentEducationCommandValidator : AbstractValidator<UpdateStudentEducationCommand>
{
    public UpdateStudentEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.EducationId).NotEmpty();
    }
}