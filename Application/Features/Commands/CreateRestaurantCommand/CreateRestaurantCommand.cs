using Application.DTOs;
using MediatR;

namespace Application.Features.Commands.CreateRestaurantCommand
{
   public class CreateRestaurantCommand : IRequest<int>
    {
        public CreateRestaurantDto RestaurantRequest { get; set; }
        public CreateRestaurantCommand(CreateRestaurantDto restaurantRequest)
        {
            RestaurantRequest = restaurantRequest;
        }
    }
}
