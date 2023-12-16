using Core.Application.Responses;

namespace Application.Features.MediaAccounts.Commands.Update;

public class UpdatedMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}