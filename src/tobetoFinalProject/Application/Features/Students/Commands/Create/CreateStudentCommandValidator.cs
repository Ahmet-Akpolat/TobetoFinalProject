using FluentValidation;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.AddressDetail).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ProfilePhotoPath).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
    }
}