using Core.Application.Dtos;

namespace Application.Features.LectureLikes.Queries.GetList;

public class GetListLectureLikeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LectureId { get; set; }
}