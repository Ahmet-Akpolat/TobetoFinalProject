using Core.Application.Responses;

namespace Application.Features.StudentStudentClasses.Queries.GetById;

public class GetByIdStudentStudentClassResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid StudentClassId { get; set; }
}