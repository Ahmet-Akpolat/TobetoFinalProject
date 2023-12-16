using Core.Application.Responses;

namespace Application.Features.LectureFavourites.Queries.GetById;

public class GetByIdLectureFavouriteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid LectureId { get; set; }
}