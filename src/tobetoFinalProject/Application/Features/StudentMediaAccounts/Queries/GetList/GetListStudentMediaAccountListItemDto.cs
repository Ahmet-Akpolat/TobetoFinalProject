using Core.Application.Dtos;

namespace Application.Features.StudentMediaAccounts.Queries.GetList;

public class GetListStudentMediaAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }
}