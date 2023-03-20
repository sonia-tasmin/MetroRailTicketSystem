using System.Security.Claims;
using TicketSystem.Application.Contracts;

#nullable disable

namespace TicketSystem.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string ClientId => _configuration["Security:ClientId"];

        public Guid? UserId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue("sub") ?? Guid.Empty.ToString());
        //public string Role => _httpContextAccessor.HttpContext?.User?.FindFirstValue("role") ?? "";

        public string Role => _configuration["Security:RoleId"];

        public string Token => _httpContextAccessor.HttpContext.Request?.Headers["Authorization"].ToString() ?? "";

    }
}
