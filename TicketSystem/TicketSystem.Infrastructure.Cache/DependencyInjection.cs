
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Contracts.Repositories.Cache;
using TicketSystem.Infrastructure.Cache.Repositories;
using TicketSystem.Application.Contracts.Repositories.Cache;
using TicketSystem.Infrastructure.Cache.Repositories;

namespace TicketSystem.Infrastructure.Cache;

public static class DependencyInjection
{
    public static IServiceCollection AddDistributedCacheServices(this IServiceCollection services)
    {
        services.AddScoped<ICacheRepository, CacheRepository>();

        return services;
    }
}
