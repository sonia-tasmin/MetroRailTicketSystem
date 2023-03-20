using MediatR;
using Shared.DTOs.User;
using Shared.Security;

namespace TicketSystem.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserGetResponseDTO>
    {
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
