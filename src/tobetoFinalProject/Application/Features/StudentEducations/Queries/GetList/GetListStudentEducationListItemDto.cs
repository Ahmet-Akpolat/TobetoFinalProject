using Core.Application.Dtos;

namespace Application.Features.StudentEducations.Queries.GetList;

public class GetListStudentEducationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid EducationId { get; set; }
}