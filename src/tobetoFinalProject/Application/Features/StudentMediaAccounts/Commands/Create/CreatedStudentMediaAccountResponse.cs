using Core.Application.Responses;

namespace Application.Features.StudentMediaAccounts.Commands.Create;

public class CreatedStudentMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }
}