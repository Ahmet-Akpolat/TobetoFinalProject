using Core.Application.Responses;

namespace Application.Features.LectureFavourites.Commands.Delete;

public class DeletedLectureFavouriteResponse : IResponse
{
    public Guid Id { get; set; }
}