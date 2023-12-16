using Core.Application.Dtos;

namespace Application.Features.Lectures.Queries.GetList;

public class GetListLectureListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string ImageUrl { get; set; }
    public double EstimatedDuration { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}