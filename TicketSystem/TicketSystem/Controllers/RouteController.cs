using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.Route;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.Route;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Route;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RouteGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllRouteQuery()));
        }

        [HttpGet("{RouteId}")]
        [ProducesDefaultResponseType(typeof(RouteGetResponseDTO))]
        public async Task<ActionResult<RouteGetResponseDTO>> Get(Guid RouteId)
        {
            return Ok(await _mediator.Send(new GetRouteByIdQuery(RouteId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RoutePostResponseDTO>>> Create([FromBody] CreateRouteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RoutePostResponseDTO>>> Update([FromBody] UpdateRouteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RoutePostResponseDTO>>> Delete(Guid RouteId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteRouteCommand(RouteId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
