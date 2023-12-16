using Core.Application.Dtos;

namespace Application.Features.LectureFavourites.Queries.GetList;

public class GetListLectureFavouriteListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid LectureId { get; set; }
}