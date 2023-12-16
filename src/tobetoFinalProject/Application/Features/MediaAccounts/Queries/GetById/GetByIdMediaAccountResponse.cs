using Core.Application.Responses;

namespace Application.Features.MediaAccounts.Queries.GetById;

public class GetByIdMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}