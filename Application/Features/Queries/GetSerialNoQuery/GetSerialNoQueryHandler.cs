using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Queries.GetSerialNoQuery
{
    public class GetSerialNoQueryHandler : IRequestHandler<GetSerialNoQuery, List<RestaurantSerialDto>>
    {
        private readonly IRestaurantService _restaurantService;

        public GetSerialNoQueryHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<List<RestaurantSerialDto>> Handle(GetSerialNoQuery request, CancellationToken cancellationToken)
        {
            var result = await _restaurantService.GetSerialNumberAsync(request.CityId);
            return result;
        }
    }
}
