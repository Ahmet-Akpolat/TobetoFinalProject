using Core.Application.Responses;

namespace Application.Features.MediaAccounts.Commands.Create;

public class CreatedMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}