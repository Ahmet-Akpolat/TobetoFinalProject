using Core.Application.Responses;

namespace Application.Features.LectureFavourites.Commands.Update;

public class UpdatedLectureFavouriteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid LectureId { get; set; }
}