using Application.DTOs;
using MediatR;

namespace Application.Features.Commands.RestaurantTaskCommand
{
    public class CreateRestaurantTaskCommand : IRequest<int>
    {
        public RestaurantTasksDto RestaurantTasks { get; set; }
    }
}
