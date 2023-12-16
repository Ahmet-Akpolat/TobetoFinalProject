using Core.Application.Dtos;

namespace Application.Features.StudentCertificates.Queries.GetList;

public class GetListStudentCertificateListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CerfiticateId { get; set; }
}