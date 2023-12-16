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

namespace Application.Features.LectureFavourites.Commands.Update;

public class UpdateLectureFavouriteCommand : IRequest<UpdatedLectureFavouriteResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid LectureId { get; set; }

    public string[] Roles => new[] { Admin, Write, LectureFavouritesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLectureFavourites";

    public class UpdateLectureFavouriteCommandHandler : IRequestHandler<UpdateLectureFavouriteCommand, UpdatedLectureFavouriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
        private readonly LectureFavouriteBusinessRules _lectureFavouriteBusinessRules;

        public UpdateLectureFavouriteCommandHandler(IMapper mapper, ILectureFavouriteRepository lectureFavouriteRepository,
                                         LectureFavouriteBusinessRules lectureFavouriteBusinessRules)
        {
            _mapper = mapper;
            _lectureFavouriteRepository = lectureFavouriteRepository;
            _lectureFavouriteBusinessRules = lectureFavouriteBusinessRules;
        }

        public async Task<UpdatedLectureFavouriteResponse> Handle(UpdateLectureFavouriteCommand request, CancellationToken cancellationToken)
        {
            LectureFavourite? lectureFavourite = await _lectureFavouriteRepository.GetAsync(predicate: lf => lf.Id == request.Id, cancellationToken: cancellationToken);
            await _lectureFavouriteBusinessRules.LectureFavouriteShouldExistWhenSelected(lectureFavourite);
            lectureFavourite = _mapper.Map(request, lectureFavourite);

            await _lectureFavouriteRepository.UpdateAsync(lectureFavourite!);

            UpdatedLectureFavouriteResponse response = _mapper.Map<UpdatedLectureFavouriteResponse>(lectureFavourite);
            return response;
        }
    }
}