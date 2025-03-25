using Application.Features.Commands.UpdateRoleCommand;
using Application.Features.Queries.GetAllUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllUsers")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
            return Ok(result);
        }
        [HttpPost("assignRoleToUser")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ActionResult([FromBody] UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
