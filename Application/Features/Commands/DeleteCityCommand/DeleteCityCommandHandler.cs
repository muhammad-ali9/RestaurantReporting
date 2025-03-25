using Application.Interfaces;
using MediatR;

namespace Application.Features.Commands.DeleteCityCommand
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly IRestaurantService _restaurantService;
        public DeleteCityCommandHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var result = await _restaurantService.DeleteCity(request.Cid);
            return result;
        }
    }
}
