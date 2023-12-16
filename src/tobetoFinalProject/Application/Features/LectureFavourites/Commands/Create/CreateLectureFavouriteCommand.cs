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

namespace Application.Features.LectureFavourites.Commands.Create;

public class CreateLectureFavouriteCommand : IRequest<CreatedLectureFavouriteResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid StudentId { get; set; }
    public Guid LectureId { get; set; }

    public string[] Roles => new[] { Admin, Write, LectureFavouritesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLectureFavourites";

    public class CreateLectureFavouriteCommandHandler : IRequestHandler<CreateLectureFavouriteCommand, CreatedLectureFavouriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
        private readonly LectureFavouriteBusinessRules _lectureFavouriteBusinessRules;

        public CreateLectureFavouriteCommandHandler(IMapper mapper, ILectureFavouriteRepository lectureFavouriteRepository,
                                         LectureFavouriteBusinessRules lectureFavouriteBusinessRules)
        {
            _mapper = mapper;
            _lectureFavouriteRepository = lectureFavouriteRepository;
            _lectureFavouriteBusinessRules = lectureFavouriteBusinessRules;
        }

        public async Task<CreatedLectureFavouriteResponse> Handle(CreateLectureFavouriteCommand request, CancellationToken cancellationToken)
        {
            LectureFavourite lectureFavourite = _mapper.Map<LectureFavourite>(request);

            await _lectureFavouriteRepository.AddAsync(lectureFavourite);

            CreatedLectureFavouriteResponse response = _mapper.Map<CreatedLectureFavouriteResponse>(lectureFavourite);
            return response;
        }
    }
}