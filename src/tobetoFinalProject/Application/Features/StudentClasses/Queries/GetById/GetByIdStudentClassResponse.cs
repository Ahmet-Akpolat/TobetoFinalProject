using Core.Application.Responses;

namespace Application.Features.StudentClasses.Queries.GetById;

public class GetByIdStudentClassResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}