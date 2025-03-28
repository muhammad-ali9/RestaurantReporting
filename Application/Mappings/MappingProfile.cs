using Application.DTOs;
using Application.Features.Commands.CreateRestaurantCommand;
using AutoMapper;
using Domain;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRestaurantCommand, CreateRestaurantDto>().ReverseMap();
            //CreateMap<CreateRestaurantDto, CreateRestaurantCommand>().ReverseMap();
            //CreateMap<RestaurantTasksDto, RestaurantTasks>().ReverseMap();
        }
    }
}
