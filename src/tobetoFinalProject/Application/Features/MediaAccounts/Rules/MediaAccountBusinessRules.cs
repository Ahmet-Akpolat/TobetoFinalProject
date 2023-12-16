using Application.Features.MediaAccounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.MediaAccounts.Rules;

public class MediaAccountBusinessRules : BaseBusinessRules
{
    private readonly IMediaAccountRepository _mediaAccountRepository;

    public MediaAccountBusinessRules(IMediaAccountRepository mediaAccountRepository)
    {
        _mediaAccountRepository = mediaAccountRepository;
    }

    public Task MediaAccountShouldExistWhenSelected(MediaAccount? mediaAccount)
    {
        if (mediaAccount == null)
            throw new BusinessException(MediaAccountsBusinessMessages.MediaAccountNotExists);
        return Task.CompletedTask;
    }

    public async Task MediaAccountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MediaAccount? mediaAccount = await _mediaAccountRepository.GetAsync(
            predicate: ma => ma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MediaAccountShouldExistWhenSelected(mediaAccount);
    }
}