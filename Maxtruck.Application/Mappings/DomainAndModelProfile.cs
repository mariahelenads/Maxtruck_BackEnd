using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Domain.Models;

namespace Maxtruck.Application.Mappings
{
    public class DomainAndModelProfile : Profile
    {
        public DomainAndModelProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, UserDto>();

            CreateMap<Bridge, BridgeDto>().ReverseMap();

            CreateMap<Truck, TruckDto>()
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height / 100)); // Metros para centimetros

            CreateMap<TruckDto, Truck>()
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height * 100)) // Centimetros para Metros
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
