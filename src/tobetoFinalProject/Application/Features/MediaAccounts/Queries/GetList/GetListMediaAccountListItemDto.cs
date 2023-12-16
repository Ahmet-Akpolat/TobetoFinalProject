using Core.Application.Dtos;

namespace Application.Features.MediaAccounts.Queries.GetList;

public class GetListMediaAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}