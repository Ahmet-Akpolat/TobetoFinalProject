using Application.Features.StudentStudentClasses.Commands.Create;
using Application.Features.StudentStudentClasses.Commands.Delete;
using Application.Features.StudentStudentClasses.Commands.Update;
using Application.Features.StudentStudentClasses.Queries.GetById;
using Application.Features.StudentStudentClasses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentStudentClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentStudentClass, CreateStudentStudentClassCommand>().ReverseMap();
        CreateMap<StudentStudentClass, CreatedStudentStudentClassResponse>().ReverseMap();
        CreateMap<StudentStudentClass, UpdateStudentStudentClassCommand>().ReverseMap();
        CreateMap<StudentStudentClass, UpdatedStudentStudentClassResponse>().ReverseMap();
        CreateMap<StudentStudentClass, DeleteStudentStudentClassCommand>().ReverseMap();
        CreateMap<StudentStudentClass, DeletedStudentStudentClassResponse>().ReverseMap();
        CreateMap<StudentStudentClass, GetByIdStudentStudentClassResponse>().ReverseMap();
        CreateMap<StudentStudentClass, GetListStudentStudentClassListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentStudentClass>, GetListResponse<GetListStudentStudentClassListItemDto>>().ReverseMap();
    }
}