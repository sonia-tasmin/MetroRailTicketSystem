using TicketSystem.Application.Contracts.Repositories;
using TicketSystem.Application.Contracts.Repositories.Command;
using TicketSystem.Application.Contracts.Repositories.Command.Base;
using TicketSystem.Application.Contracts.Repositories.Query;
using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Infrastructure.Configs;
using TicketSystem.Infrastructure.Persistence;
using TicketSystem.Infrastructure.Repository;
using TicketSystem.Infrastructure.Repository.Command;
using TicketSystem.Infrastructure.Repository.Command.Base;
using TicketSystem.Infrastructure.Repository.Query;
using TicketSystem.Infrastructure.Repository.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TicketSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TicketSystemSettings>(configuration);
            var serviceProvider = services.BuildServiceProvider();
            var opt = serviceProvider.GetRequiredService<IOptions<TicketSystemSettings>>().Value;
            // For SQLServer Connection
            services.AddDbContext<TicketSystemDbContext>(options =>
            {
                options.UseSqlServer(opt.ConnectionStrings.TicketSystemDbConnection, sqlServerOptionsAction: sqlOptions =>
                {
                });
            });
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(IMultipleResultQueryRepository<>), typeof(MultipleResultQueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Func<TicketSystemDbContext>>((provider) => provider.GetService<TicketSystemDbContext>);
            services.AddScoped<DbFactory>();
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
           
            services.AddScoped<ISeatCommandRepository, SeatCommandRepository>();
            services.AddScoped<ISeatQueryRepository, SeatQueryRepository>();

            services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
            services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

            services.AddScoped<IRouteCommandRepository, RouteCommandRepository>();
            services.AddScoped<IRouteQueryRepository, RouteQueryRepository>();

            services.AddScoped<ITrainCommandRepository, TrainCommandRepository>();
            services.AddScoped<ITrainQueryRepository, TrainQueryRepository>();

            services.AddScoped<IRouteTrainCommandRepository, RouteTrainCommandRepository>();
            services.AddScoped<IRouteTrainQueryRepository, RouteTrainQueryRepository>();

            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();

            return services;
        }
    }
}