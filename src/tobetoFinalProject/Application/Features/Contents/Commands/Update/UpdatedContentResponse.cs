using Core.Application.Responses;

namespace Application.Features.Contents.Commands.Update;

public class UpdatedContentResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid LanguageId { get; set; }
    public string VideoUrl { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime Duration { get; set; }
    public Guid? ContentCategoryId { get; set; }
}