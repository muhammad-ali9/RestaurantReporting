using Application.DTOs;
using Application.Interfaces.Context;
using Application.Services;
using MediatR;

namespace Application.Features.Queries.GetAllUserQuery
{
   public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDetailsDto>>
    {
        private readonly IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<UserDetailsDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync();
            return users;
        }
    }
    
}
