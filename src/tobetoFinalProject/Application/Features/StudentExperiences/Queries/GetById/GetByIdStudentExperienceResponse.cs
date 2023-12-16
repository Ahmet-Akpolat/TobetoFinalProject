using Core.Application.Responses;

namespace Application.Features.StudentExperiences.Queries.GetById;

public class GetByIdStudentExperienceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExperienceId { get; set; }
}