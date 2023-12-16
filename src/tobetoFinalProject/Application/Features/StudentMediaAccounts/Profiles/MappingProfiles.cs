using Application.Features.StudentMediaAccounts.Commands.Create;
using Application.Features.StudentMediaAccounts.Commands.Delete;
using Application.Features.StudentMediaAccounts.Commands.Update;
using Application.Features.StudentMediaAccounts.Queries.GetById;
using Application.Features.StudentMediaAccounts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentMediaAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentMediaAccount, CreateStudentMediaAccountCommand>().ReverseMap();
        CreateMap<StudentMediaAccount, CreatedStudentMediaAccountResponse>().ReverseMap();
        CreateMap<StudentMediaAccount, UpdateStudentMediaAccountCommand>().ReverseMap();
        CreateMap<StudentMediaAccount, UpdatedStudentMediaAccountResponse>().ReverseMap();
        CreateMap<StudentMediaAccount, DeleteStudentMediaAccountCommand>().ReverseMap();
        CreateMap<StudentMediaAccount, DeletedStudentMediaAccountResponse>().ReverseMap();
        CreateMap<StudentMediaAccount, GetByIdStudentMediaAccountResponse>().ReverseMap();
        CreateMap<StudentMediaAccount, GetListStudentMediaAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentMediaAccount>, GetListResponse<GetListStudentMediaAccountListItemDto>>().ReverseMap();
    }
}