using AutoMapper;
using FinanceApi.Application.Dtos;
using FinanceApi.Domain.Entities;

namespace FinanceApi.Application.Profiles;

public class SalesOrderProfile : Profile
{
    public SalesOrderProfile()
    {
        CreateMap<SalesOrder, SalesOrderDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SalesOrderDetailDtos,
                opt => opt.MapFrom(src => src.SalesOrderDetails))
            .ReverseMap()
            .ForMember(dest => dest.SalesOrderDetails,
                opt => opt.MapFrom(src => src.SalesOrderDetailDtos));
    }
}