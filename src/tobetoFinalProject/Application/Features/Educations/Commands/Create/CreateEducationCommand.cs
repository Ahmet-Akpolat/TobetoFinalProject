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

namespace Application.Features.Educations.Commands.Create;

public class CreateEducationCommand : IRequest<CreatedEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string EducationStatus { get; set; }
    public string SchoolName { get; set; }
    public string Branch { get; set; }
    public bool IsContinued { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducations";

    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, CreatedEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public CreateEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository,
                                         EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<CreatedEducationResponse> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            Education education = _mapper.Map<Education>(request);

            await _educationRepository.AddAsync(education);

            CreatedEducationResponse response = _mapper.Map<CreatedEducationResponse>(education);
            return response;
        }
    }
}