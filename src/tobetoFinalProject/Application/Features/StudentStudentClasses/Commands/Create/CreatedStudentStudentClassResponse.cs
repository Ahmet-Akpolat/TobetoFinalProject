using Core.Application.Responses;

namespace Application.Features.StudentStudentClasses.Commands.Create;

public class CreatedStudentStudentClassResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid StudentClassId { get; set; }
}