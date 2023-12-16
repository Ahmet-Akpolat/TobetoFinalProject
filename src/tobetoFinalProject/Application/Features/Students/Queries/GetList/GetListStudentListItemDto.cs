using Core.Application.Dtos;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public string Country { get; set; }
}