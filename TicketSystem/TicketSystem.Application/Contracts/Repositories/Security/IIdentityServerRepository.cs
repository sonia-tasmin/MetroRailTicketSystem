
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Common.Models;

namespace TicketSystem.Application.Contracts.Repositories.Security;

public interface IIdentityServerRepository
{
    Task<IEnumerable<IdentityServerAccessConfiguration>> GetPermissions(string token, string clientId, string roleId);
}
