using Core.Application.Responses;

namespace Application.Features.StudentStudentClasses.Commands.Delete;

public class DeletedStudentStudentClassResponse : IResponse
{
    public Guid Id { get; set; }
}