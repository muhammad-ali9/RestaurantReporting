using MediatR;

namespace Application.Features.Commands.DeleteRestaurantCommand
{
    public class DeleteRestaurantCommand : IRequest<int>
    {
        public int Id { get; set; }
        
    }
}
