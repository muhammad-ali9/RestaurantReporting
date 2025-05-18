using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Queries.GetUserTasksQuery
{
    public class GetUserTasksQueryHandler : IRequestHandler<GetUserTasksQuery, List<UsersTaskDto>>
    {
        private readonly IRestaurantTasks _restaurantTasks;
        public GetUserTasksQueryHandler(IRestaurantTasks restaurantTasks)
        {
            _restaurantTasks = restaurantTasks;
        }
        public Task<List<UsersTaskDto>> Handle(GetUserTasksQuery request, CancellationToken cancellationToken)
        {
            return _restaurantTasks.GetUserTasksAsync();
        }
    }
}
