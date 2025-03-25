using Application.Services;
using MediatR;

namespace Application.Features.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IUserService _userService;
        public UpdateRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.AssignRole(request.Id, request.Role);
            return result;
        }
    }
}
