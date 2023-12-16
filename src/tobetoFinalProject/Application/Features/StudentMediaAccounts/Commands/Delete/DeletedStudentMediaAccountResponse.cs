using Core.Application.Responses;

namespace Application.Features.StudentMediaAccounts.Commands.Delete;

public class DeletedStudentMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
}