using Core.Application.Responses;

namespace Application.Features.Experiences.Commands.Create;

public class CreatedExperienceResponse : IResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Sector { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
    public Guid CityId { get; set; }
}