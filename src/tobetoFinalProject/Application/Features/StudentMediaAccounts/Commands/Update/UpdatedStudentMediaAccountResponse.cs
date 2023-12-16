using Core.Application.Responses;

namespace Application.Features.StudentMediaAccounts.Commands.Update;

public class UpdatedStudentMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }
}