using AutoMapper;
using FinanceApi.Application.Dtos;
using FinanceApi.Domain.Entities;

namespace FinanceApi.Application.Profiles;

public class SalesOrderDetailProfile : Profile
{
    public SalesOrderDetailProfile()
    {
        CreateMap<SalesOrderDetail, SalesOrderDetailDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SalesOrderId,
                opt => opt.MapFrom(src => src.SalesOrderId))
            .ReverseMap();
    }
}