using Core.Application.Responses;

namespace Application.Features.StudentExperiences.Commands.Update;

public class UpdatedStudentExperienceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExperienceId { get; set; }
}