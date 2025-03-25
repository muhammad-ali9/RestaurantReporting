using MediatR;

namespace Application.Features.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
