using Application.Features.Experiences.Constants;
using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Experiences.Constants.ExperiencesOperationClaims;

namespace Application.Features.Experiences.Commands.Update;

public class UpdateExperienceCommand : IRequest<UpdatedExperienceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Sector { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
    public Guid CityId { get; set; }

    public string[] Roles => new[] { Admin, Write, ExperiencesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExperiences";

    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, UpdatedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public UpdateExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<UpdatedExperienceResponse> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);
            experience = _mapper.Map(request, experience);

            await _experienceRepository.UpdateAsync(experience!);

            UpdatedExperienceResponse response = _mapper.Map<UpdatedExperienceResponse>(experience);
            return response;
        }
    }
}