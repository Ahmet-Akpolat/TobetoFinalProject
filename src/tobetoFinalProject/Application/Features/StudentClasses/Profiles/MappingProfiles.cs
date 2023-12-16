using Application.Features.StudentClasses.Commands.Create;
using Application.Features.StudentClasses.Commands.Delete;
using Application.Features.StudentClasses.Commands.Update;
using Application.Features.StudentClasses.Queries.GetById;
using Application.Features.StudentClasses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentClass, CreateStudentClassCommand>().ReverseMap();
        CreateMap<StudentClass, CreatedStudentClassResponse>().ReverseMap();
        CreateMap<StudentClass, UpdateStudentClassCommand>().ReverseMap();
        CreateMap<StudentClass, UpdatedStudentClassResponse>().ReverseMap();
        CreateMap<StudentClass, DeleteStudentClassCommand>().ReverseMap();
        CreateMap<StudentClass, DeletedStudentClassResponse>().ReverseMap();
        CreateMap<StudentClass, GetByIdStudentClassResponse>().ReverseMap();
        CreateMap<StudentClass, GetListStudentClassListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentClass>, GetListResponse<GetListStudentClassListItemDto>>().ReverseMap();
    }
}