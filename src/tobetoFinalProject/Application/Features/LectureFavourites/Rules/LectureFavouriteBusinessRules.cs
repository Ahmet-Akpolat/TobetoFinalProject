using Application.Features.LectureFavourites.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LectureFavourites.Rules;

public class LectureFavouriteBusinessRules : BaseBusinessRules
{
    private readonly ILectureFavouriteRepository _lectureFavouriteRepository;

    public LectureFavouriteBusinessRules(ILectureFavouriteRepository lectureFavouriteRepository)
    {
        _lectureFavouriteRepository = lectureFavouriteRepository;
    }

    public Task LectureFavouriteShouldExistWhenSelected(LectureFavourite? lectureFavourite)
    {
        if (lectureFavourite == null)
            throw new BusinessException(LectureFavouritesBusinessMessages.LectureFavouriteNotExists);
        return Task.CompletedTask;
    }

    public async Task LectureFavouriteIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        LectureFavourite? lectureFavourite = await _lectureFavouriteRepository.GetAsync(
            predicate: lf => lf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LectureFavouriteShouldExistWhenSelected(lectureFavourite);
    }
}