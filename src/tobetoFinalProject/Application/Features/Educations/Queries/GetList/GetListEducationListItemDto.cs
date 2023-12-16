using Core.Application.Dtos;

namespace Application.Features.Educations.Queries.GetList;

public class GetListEducationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string EducationStatus { get; set; }
    public string SchoolName { get; set; }
    public string Branch { get; set; }
    public bool IsContinued { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }
}