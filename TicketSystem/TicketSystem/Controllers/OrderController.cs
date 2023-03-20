using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.Order;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.Order;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.Order;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllOrderQuery()));
        }

        [HttpGet("{Guid}")]
        [ProducesDefaultResponseType(typeof(OrderGetResponseDTO))]
        public async Task<ActionResult<OrderGetResponseDTO>> Get(Guid OrderId)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery(OrderId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, OrderPostResponseDTO>>> Create([FromBody] CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, OrderPostResponseDTO>>> Update([FromBody] UpdateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, OrderPostResponseDTO>>> Delete(Guid OrderId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteOrderCommand(OrderId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
