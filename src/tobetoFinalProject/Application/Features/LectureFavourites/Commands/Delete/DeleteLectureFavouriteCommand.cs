using Application.Features.LectureFavourites.Constants;
using Application.Features.LectureFavourites.Constants;
using Application.Features.LectureFavourites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LectureFavourites.Constants.LectureFavouritesOperationClaims;

namespace Application.Features.LectureFavourites.Commands.Delete;

public class DeleteLectureFavouriteCommand : IRequest<DeletedLectureFavouriteResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LectureFavouritesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLectureFavourites";

    public class DeleteLectureFavouriteCommandHandler : IRequestHandler<DeleteLectureFavouriteCommand, DeletedLectureFavouriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
        private readonly LectureFavouriteBusinessRules _lectureFavouriteBusinessRules;

        public DeleteLectureFavouriteCommandHandler(IMapper mapper, ILectureFavouriteRepository lectureFavouriteRepository,
                                         LectureFavouriteBusinessRules lectureFavouriteBusinessRules)
        {
            _mapper = mapper;
            _lectureFavouriteRepository = lectureFavouriteRepository;
            _lectureFavouriteBusinessRules = lectureFavouriteBusinessRules;
        }

        public async Task<DeletedLectureFavouriteResponse> Handle(DeleteLectureFavouriteCommand request, CancellationToken cancellationToken)
        {
            LectureFavourite? lectureFavourite = await _lectureFavouriteRepository.GetAsync(predicate: lf => lf.Id == request.Id, cancellationToken: cancellationToken);
            await _lectureFavouriteBusinessRules.LectureFavouriteShouldExistWhenSelected(lectureFavourite);

            await _lectureFavouriteRepository.DeleteAsync(lectureFavourite!);

            DeletedLectureFavouriteResponse response = _mapper.Map<DeletedLectureFavouriteResponse>(lectureFavourite);
            return response;
        }
    }
}