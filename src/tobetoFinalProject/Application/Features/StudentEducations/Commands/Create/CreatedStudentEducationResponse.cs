using Core.Application.Responses;

namespace Application.Features.StudentEducations.Commands.Create;

public class CreatedStudentEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid EducationId { get; set; }
}