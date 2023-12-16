using Application.Features.LectureFavourites.Constants;
using Application.Features.LectureFavourites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LectureFavourites.Constants.LectureFavouritesOperationClaims;

namespace Application.Features.LectureFavourites.Queries.GetById;

public class GetByIdLectureFavouriteQuery : IRequest<GetByIdLectureFavouriteResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdLectureFavouriteQueryHandler : IRequestHandler<GetByIdLectureFavouriteQuery, GetByIdLectureFavouriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILectureFavouriteRepository _lectureFavouriteRepository;
        private readonly LectureFavouriteBusinessRules _lectureFavouriteBusinessRules;

        public GetByIdLectureFavouriteQueryHandler(IMapper mapper, ILectureFavouriteRepository lectureFavouriteRepository, LectureFavouriteBusinessRules lectureFavouriteBusinessRules)
        {
            _mapper = mapper;
            _lectureFavouriteRepository = lectureFavouriteRepository;
            _lectureFavouriteBusinessRules = lectureFavouriteBusinessRules;
        }

        public async Task<GetByIdLectureFavouriteResponse> Handle(GetByIdLectureFavouriteQuery request, CancellationToken cancellationToken)
        {
            LectureFavourite? lectureFavourite = await _lectureFavouriteRepository.GetAsync(predicate: lf => lf.Id == request.Id, cancellationToken: cancellationToken);
            await _lectureFavouriteBusinessRules.LectureFavouriteShouldExistWhenSelected(lectureFavourite);

            GetByIdLectureFavouriteResponse response = _mapper.Map<GetByIdLectureFavouriteResponse>(lectureFavourite);
            return response;
        }
    }
}