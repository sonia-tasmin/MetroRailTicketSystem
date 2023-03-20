using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.RouteTrain;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.RouteTrain;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.RouteTrain;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class RouteTrainController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RouteTrainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RouteTrainGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllRouteTrainQuery()));
        }

        [HttpGet("{Guid}")]
        [ProducesDefaultResponseType(typeof(RouteTrainGetResponseDTO))]
        public async Task<ActionResult<RouteTrainGetResponseDTO>> Get(Guid RouteTrainId)
        {
            return Ok(await _mediator.Send(new GetRouteTrainByIdQuery(RouteTrainId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RouteTrainPostResponseDTO>>> Create([FromBody] CreateRouteTrainCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RouteTrainPostResponseDTO>>> Update([FromBody] UpdateRouteTrainCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, RouteTrainPostResponseDTO>>> Delete(Guid RouteTrainId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteRouteTrainCommand(RouteTrainId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
