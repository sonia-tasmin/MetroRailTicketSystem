
using TicketSystem.Application.Common.Models;

namespace TicketSystem.Application.Common.Models;

public class IdentityServerAccessConfiguration
{
    public string RoleId { get; set; }
    public int PermissionId { get; set; }
    public string ClientId { get; set; }
    public IdentityServerRoleConfiguration Role { get; set; }
    public IdentityServerPermissionConfiguration Permission { get; set; }
}
