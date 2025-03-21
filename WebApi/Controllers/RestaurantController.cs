﻿using Application.Features.Commands.CreateRestaurantCommand;
using Application.Features.Commands.DeleteRestaurantCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createRestaurants")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateRestaurants([FromBody] CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        [HttpPost("deleteRestaurants")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteRestaurants([FromBody] DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
