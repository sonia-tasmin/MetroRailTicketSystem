using MediatR;
using Microsoft.Extensions.Configuration;
using TicketSystem.Application.Contracts;
using TicketSystem.Application.Contracts.Repositories.Security;
using Shared.Security;
using System.Reflection;

namespace TicketSystem.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityServerRepository _identityServerRepository;
    private readonly IConfiguration _configuration;

    public AuthorizationBehaviour(ICurrentUserService currentUserService, IIdentityServerRepository identityServerRepository, IConfiguration configuration)
    {
        _currentUserService = currentUserService;
        _identityServerRepository = identityServerRepository;
        _configuration = configuration;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        bool checkAuthorization;
        if (bool.TryParse(_configuration["Security:CheckAuthorization"], out checkAuthorization) && !checkAuthorization)
            return await next();

        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            var accessConfigs = await _identityServerRepository.GetPermissions(_currentUserService.Token, _currentUserService.ClientId, _currentUserService.Role);

            var permissions = authorizeAttributes.SelectMany(a => a.Permissions.Split(',')).ToList();

            if (!permissions.Any())
                throw new UnauthorizedAccessException("This API resource doesn't have any permission defined!");
            if (accessConfigs == null || !accessConfigs.Any())
                throw new UnauthorizedAccessException("This user role doesn't have any permission defined!");

            if (!accessConfigs.Select(a => a.Permission?.Name ?? "").Any(p => permissions.Contains(p)))
                throw new UnauthorizedAccessException();
        }

        return await next();
    }
}
