using Application.Features.Educations.Constants;
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

namespace Application.Features.Educations.Commands.Delete;

public class DeleteEducationCommand : IRequest<DeletedEducationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, EducationsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetEducations";

    public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand, DeletedEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public DeleteEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository,
                                         EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<DeletedEducationResponse> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            Education? education = await _educationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _educationBusinessRules.EducationShouldExistWhenSelected(education);

            await _educationRepository.DeleteAsync(education!);

            DeletedEducationResponse response = _mapper.Map<DeletedEducationResponse>(education);
            return response;
        }
    }
}