using Core.Application.Responses;

namespace Application.Features.MediaAccounts.Commands.Delete;

public class DeletedMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
}