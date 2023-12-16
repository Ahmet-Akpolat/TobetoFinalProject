using Core.Application.Responses;

namespace Application.Features.LectureLikes.Commands.Create;

public class CreatedLectureLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LectureId { get; set; }
}