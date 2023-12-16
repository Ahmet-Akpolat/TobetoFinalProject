using Application.Features.MediaAccounts.Commands.Create;
using Application.Features.MediaAccounts.Commands.Delete;
using Application.Features.MediaAccounts.Commands.Update;
using Application.Features.MediaAccounts.Queries.GetById;
using Application.Features.MediaAccounts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.MediaAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MediaAccount, CreateMediaAccountCommand>().ReverseMap();
        CreateMap<MediaAccount, CreatedMediaAccountResponse>().ReverseMap();
        CreateMap<MediaAccount, UpdateMediaAccountCommand>().ReverseMap();
        CreateMap<MediaAccount, UpdatedMediaAccountResponse>().ReverseMap();
        CreateMap<MediaAccount, DeleteMediaAccountCommand>().ReverseMap();
        CreateMap<MediaAccount, DeletedMediaAccountResponse>().ReverseMap();
        CreateMap<MediaAccount, GetByIdMediaAccountResponse>().ReverseMap();
        CreateMap<MediaAccount, GetListMediaAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<MediaAccount>, GetListResponse<GetListMediaAccountListItemDto>>().ReverseMap();
    }
}