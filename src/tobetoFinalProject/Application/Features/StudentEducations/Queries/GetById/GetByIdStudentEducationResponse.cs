using Core.Application.Responses;

namespace Application.Features.StudentEducations.Queries.GetById;

public class GetByIdStudentEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid EducationId { get; set; }
}