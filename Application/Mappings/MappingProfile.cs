using Application.DTOs;
using Application.Features.Commands.CreateRestaurantCommand;
using AutoMapper;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRestaurantCommand, CreateRestaurantDto>().ReverseMap();
        }
    }
}
