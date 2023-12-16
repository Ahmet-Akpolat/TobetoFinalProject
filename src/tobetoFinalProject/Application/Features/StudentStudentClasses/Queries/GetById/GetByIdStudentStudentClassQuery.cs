using Application.Features.StudentStudentClasses.Constants;
using Application.Features.StudentStudentClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentStudentClasses.Constants.StudentStudentClassesOperationClaims;

namespace Application.Features.StudentStudentClasses.Queries.GetById;

public class GetByIdStudentStudentClassQuery : IRequest<GetByIdStudentStudentClassResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentStudentClassQueryHandler : IRequestHandler<GetByIdStudentStudentClassQuery, GetByIdStudentStudentClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentStudentClassRepository _studentStudentClassRepository;
        private readonly StudentStudentClassBusinessRules _studentStudentClassBusinessRules;

        public GetByIdStudentStudentClassQueryHandler(IMapper mapper, IStudentStudentClassRepository studentStudentClassRepository, StudentStudentClassBusinessRules studentStudentClassBusinessRules)
        {
            _mapper = mapper;
            _studentStudentClassRepository = studentStudentClassRepository;
            _studentStudentClassBusinessRules = studentStudentClassBusinessRules;
        }

        public async Task<GetByIdStudentStudentClassResponse> Handle(GetByIdStudentStudentClassQuery request, CancellationToken cancellationToken)
        {
            StudentStudentClass? studentStudentClass = await _studentStudentClassRepository.GetAsync(predicate: ssc => ssc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentStudentClassBusinessRules.StudentStudentClassShouldExistWhenSelected(studentStudentClass);

            GetByIdStudentStudentClassResponse response = _mapper.Map<GetByIdStudentStudentClassResponse>(studentStudentClass);
            return response;
        }
    }
}