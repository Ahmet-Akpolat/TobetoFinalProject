using Core.Application.Dtos;

namespace Application.Features.StudentStudentClasses.Queries.GetList;

public class GetListStudentStudentClassListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid StudentClassId { get; set; }
}