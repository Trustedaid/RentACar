using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

/*
 public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListItemDto>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
    }
}
*/

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, GetListModelListItemDto>()
            .ForMember(destinationMember: x => x.BrandName, memberOptions: x => x.MapFrom(x => x.Brand.Name))
            .ForMember(destinationMember: x => x.FuelName, memberOptions: x => x.MapFrom(x => x.Fuel.Name))
            .ForMember(destinationMember: x => x.TransmissionName,
                memberOptions: x => x.MapFrom(x => x.Transmission.Name))
            .ReverseMap();
        CreateMap<Model, GetListByDynamicModelListItemDto>()
            .ForMember(destinationMember: x => x.BrandName, memberOptions: x => x.MapFrom(x => x.Brand.Name))
            .ForMember(destinationMember: x => x.FuelName, memberOptions: x => x.MapFrom(x => x.Fuel.Name))
            .ForMember(destinationMember: x => x.TransmissionName,
                memberOptions: x => x.MapFrom(x => x.Transmission.Name))
            .ReverseMap();

        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
    }
}