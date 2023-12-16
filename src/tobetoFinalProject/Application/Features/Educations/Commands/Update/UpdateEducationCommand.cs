using Application.Features.Educations.Constants;
using Application.Features.Educations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Educations.Constants.EducationsOperationClaims;

namespace Application.Features.Educations.Commands.Update;

public class UpdateEducationCommand : IRequest<UpdatedEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string EducationStatus { get; set; }
    public string SchoolName { get; set; }
    public string Branch { get; set; }
    public bool IsContinued { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducations";

    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, UpdatedEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public UpdateEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository,
                                         EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<UpdatedEducationResponse> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            Education? education = await _educationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _educationBusinessRules.EducationShouldExistWhenSelected(education);
            education = _mapper.Map(request, education);

            await _educationRepository.UpdateAsync(education!);

            UpdatedEducationResponse response = _mapper.Map<UpdatedEducationResponse>(education);
            return response;
        }
    }
}