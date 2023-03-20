using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Queries.User;
using TicketSystem.Shared.DTOs.Base;
using Shared.Commands.User;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs.User;
using TicketSystem.Application.Queries.UserValidate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TicketSystem.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserGetResponseDTO>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUserQuery()));
        }

        [HttpGet("{Guid}")]
        [ProducesDefaultResponseType(typeof(UserGetResponseDTO))]
        public async Task<ActionResult<UserGetResponseDTO>> Get(Guid UserId)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery(UserId)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, UserPostResponseDTO>>> Create([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, UserPostResponseDTO>>> Update([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(CustomError))]
        public async Task<ActionResult<BasePostResponseDTO<Guid, UserPostResponseDTO>>> Delete(Guid UserId)
        {
            try
            {
                var response = await _mediator.Send(new DeleteUserCommand(UserId));
                return Ok(response);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet("Login")]
    
        public async Task<ActionResult> Login(string email,string password)
        {
            try
            {
                var response = await _mediator.Send(new GetuserValidateQuery(email,password));
                if(response == null)
                {
                    return Ok(new { result = false });
                }
                return Ok(new {result=true});
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
