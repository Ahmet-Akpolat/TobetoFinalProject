using Core.Application.Responses;

namespace Application.Features.LectureLikes.Queries.GetById;

public class GetByIdLectureLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LectureId { get; set; }
}