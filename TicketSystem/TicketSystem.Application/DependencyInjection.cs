using TicketSystem.Application.Common.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketSystem.Application.Contracts.Repositories.Security;
using TicketSystem.Application.Common.Security;
using FluentValidation;
using MediatR;

namespace TicketSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddOptions();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));

            services.AddScoped<IIdentityServerRepository, IdentityServerRepository>();

            return services;
        }
    }
}
