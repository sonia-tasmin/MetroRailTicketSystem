using MediatR;
using TicketSystem.Shared.DTOs.Base;
using Shared.DTOs.User;
using Shared.Security;

namespace TicketSystem.Application.Queries.User
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserGetResponseDTO>>
    {

    }
}
