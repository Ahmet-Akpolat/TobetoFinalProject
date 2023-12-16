using FluentValidation;

namespace Application.Features.StudentEducations.Commands.Create;

public class CreateStudentEducationCommandValidator : AbstractValidator<CreateStudentEducationCommand>
{
    public CreateStudentEducationCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.EducationId).NotEmpty();
    }
}