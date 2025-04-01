using Application.DTOs;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Queries.GetAllCitiesQuery
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<string>>
    {
        private readonly IRestaurantService _restaurantService;

        public GetAllCitiesQueryHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<List<string>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _restaurantService.GetAllCitiesAsync();
            return cities;
        }
    }
}
