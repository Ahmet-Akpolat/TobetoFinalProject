using Application.Features.LectureFavourites.Commands.Create;
using Application.Features.LectureFavourites.Commands.Delete;
using Application.Features.LectureFavourites.Commands.Update;
using Application.Features.LectureFavourites.Queries.GetById;
using Application.Features.LectureFavourites.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LectureFavourites.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LectureFavourite, CreateLectureFavouriteCommand>().ReverseMap();
        CreateMap<LectureFavourite, CreatedLectureFavouriteResponse>().ReverseMap();
        CreateMap<LectureFavourite, UpdateLectureFavouriteCommand>().ReverseMap();
        CreateMap<LectureFavourite, UpdatedLectureFavouriteResponse>().ReverseMap();
        CreateMap<LectureFavourite, DeleteLectureFavouriteCommand>().ReverseMap();
        CreateMap<LectureFavourite, DeletedLectureFavouriteResponse>().ReverseMap();
        CreateMap<LectureFavourite, GetByIdLectureFavouriteResponse>().ReverseMap();
        CreateMap<LectureFavourite, GetListLectureFavouriteListItemDto>().ReverseMap();
        CreateMap<IPaginate<LectureFavourite>, GetListResponse<GetListLectureFavouriteListItemDto>>().ReverseMap();
    }
}