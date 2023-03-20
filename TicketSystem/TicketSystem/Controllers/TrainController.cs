using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.Train;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.Train;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Train;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class TrainController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TrainGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTrainQuery()));
        }

        [HttpGet("{Guid}")]
        [ProducesDefaultResponseType(typeof(TrainGetResponseDTO))]
        public async Task<ActionResult<TrainGetResponseDTO>> Get(Guid TrainId)
        {
            return Ok(await _mediator.Send(new GetTrainByIdQuery(TrainId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, TrainPostResponseDTO>>> Create([FromBody] CreateTrainCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, TrainPostResponseDTO>>> Update([FromBody] UpdateTrainCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, TrainPostResponseDTO>>> Delete(Guid TrainId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteTrainCommand(TrainId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
