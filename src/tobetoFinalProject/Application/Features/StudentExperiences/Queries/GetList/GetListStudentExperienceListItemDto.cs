using Core.Application.Dtos;

namespace Application.Features.StudentExperiences.Queries.GetList;

public class GetListStudentExperienceListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExperienceId { get; set; }
}