using AutoMapper;
using Maxtruck.Application.Dtos;
using Maxtruck.Domain.Models;

namespace Maxtruck.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, UserDto>();

            CreateMap<Bridge, BridgeDto>().ReverseMap();

            CreateMap<Truck, TruckDto>();
            CreateMap<TruckDto, Truck>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
