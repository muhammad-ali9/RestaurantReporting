using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Commands.DeleteRestaurantCommand
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, int>
    {
        private readonly IRestaurantService _restauratnService;
        public DeleteRestaurantCommandHandler(IRestaurantService restauratnService)
        {
            _restauratnService = restauratnService;
        }
        public async Task<int> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = await _restauratnService.DeleteRestauratnAsync(request.Id);
            return result;
        }
    }
}
