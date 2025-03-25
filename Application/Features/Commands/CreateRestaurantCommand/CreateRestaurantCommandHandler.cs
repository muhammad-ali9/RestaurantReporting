using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.CreateRestaurantCommand
{
    class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<CreateRestaurantDto>(request.RestaurantRequest);
            var result = await _restaurantService.CreateRestaurantAsync(data);
            return result;
        }
    }
}
