using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.Seat;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.Seat;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Seat;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SeatGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllSeatQuery()));
        }

        [HttpGet("{Guid}")]
        [ProducesDefaultResponseType(typeof(SeatGetResponseDTO))]
        public async Task<ActionResult<SeatGetResponseDTO>> Get(Guid SeatId)
        {
            return Ok(await _mediator.Send(new GetSeatByIdQuery(SeatId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, SeatPostResponseDTO>>> Create([FromBody] CreateSeatCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, SeatPostResponseDTO>>> Update([FromBody] UpdateSeatCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, SeatPostResponseDTO>>> Delete(Guid SeatId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteSeatCommand(SeatId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
