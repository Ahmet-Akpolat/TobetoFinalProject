using Core.Application.Dtos;

namespace Application.Features.StudentClasses.Queries.GetList;

public class GetListStudentClassListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}