using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.RestaurantTaskCommand
{
    public class CreateRestaurantTaskCommandHandler : IRequestHandler<CreateRestaurantTaskCommand, int>
    {
        private readonly IRestaurantTasks _restaurantTask;
        private readonly IMapper _mapper;
        public CreateRestaurantTaskCommandHandler(IRestaurantTasks restaurantService, IMapper mapper)
        {
            _restaurantTask = restaurantService;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateRestaurantTaskCommand request, CancellationToken cancellationToken)
        {

            var result = await _restaurantTask.CreateRestaurantTaskAsync(request.RestaurantTasks);
            return 1;
        }
    }
}
