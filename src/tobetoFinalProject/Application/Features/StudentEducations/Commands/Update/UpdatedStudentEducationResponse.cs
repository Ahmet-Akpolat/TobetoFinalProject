using Core.Application.Responses;

namespace Application.Features.StudentEducations.Commands.Update;

public class UpdatedStudentEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid EducationId { get; set; }
}