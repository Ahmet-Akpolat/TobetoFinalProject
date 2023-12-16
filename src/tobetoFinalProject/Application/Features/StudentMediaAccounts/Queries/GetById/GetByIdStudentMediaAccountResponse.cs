using Core.Application.Responses;

namespace Application.Features.StudentMediaAccounts.Queries.GetById;

public class GetByIdStudentMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }
}