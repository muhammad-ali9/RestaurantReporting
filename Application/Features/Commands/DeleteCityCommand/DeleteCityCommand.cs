using MediatR;

namespace Application.Features.Commands.DeleteCityCommand
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Cid { get; set; }
    }
}
