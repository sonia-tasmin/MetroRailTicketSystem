
namespace TicketSystem.Application.Common.Models;

public class IdentityServerRoleConfiguration
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public bool IsDeletable { get; set; }
    public string DisplayName { get; set; }
    public int RoleOrder { get; set; }
    public string Duration { get; set; }
    public bool WorkingDayReopen { get; set; }
    public object Users { get; set; }
}
