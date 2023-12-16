using Application.Features.MediaAccounts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MediaAccounts;

public class MediaAccountsManager : IMediaAccountsService
{
    private readonly IMediaAccountRepository _mediaAccountRepository;
    private readonly MediaAccountBusinessRules _mediaAccountBusinessRules;

    public MediaAccountsManager(IMediaAccountRepository mediaAccountRepository, MediaAccountBusinessRules mediaAccountBusinessRules)
    {
        _mediaAccountRepository = mediaAccountRepository;
        _mediaAccountBusinessRules = mediaAccountBusinessRules;
    }

    public async Task<MediaAccount?> GetAsync(
        Expression<Func<MediaAccount, bool>> predicate,
        Func<IQueryable<MediaAccount>, IIncludableQueryable<MediaAccount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MediaAccount? mediaAccount = await _mediaAccountRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return mediaAccount;
    }

    public async Task<IPaginate<MediaAccount>?> GetListAsync(
        Expression<Func<MediaAccount, bool>>? predicate = null,
        Func<IQueryable<MediaAccount>, IOrderedQueryable<MediaAccount>>? orderBy = null,
        Func<IQueryable<MediaAccount>, IIncludableQueryable<MediaAccount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MediaAccount> mediaAccountList = await _mediaAccountRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return mediaAccountList;
    }

    public async Task<MediaAccount> AddAsync(MediaAccount mediaAccount)
    {
        MediaAccount addedMediaAccount = await _mediaAccountRepository.AddAsync(mediaAccount);

        return addedMediaAccount;
    }

    public async Task<MediaAccount> UpdateAsync(MediaAccount mediaAccount)
    {
        MediaAccount updatedMediaAccount = await _mediaAccountRepository.UpdateAsync(mediaAccount);

        return updatedMediaAccount;
    }

    public async Task<MediaAccount> DeleteAsync(MediaAccount mediaAccount, bool permanent = false)
    {
        MediaAccount deletedMediaAccount = await _mediaAccountRepository.DeleteAsync(mediaAccount);

        return deletedMediaAccount;
    }
}
