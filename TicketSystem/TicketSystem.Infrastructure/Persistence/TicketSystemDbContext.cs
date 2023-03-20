using ticket = TicketSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TicketSystem.Infrastructure.Persistence
{
    public class TicketSystemDbContext : DbContext
    {
        public TicketSystemDbContext(DbContextOptions<TicketSystemDbContext> options) : base(options)
        {

        }
        //tables
        public DbSet<ticket.Seat> Seats { get; set; } = null;
        public DbSet<ticket.Route> Routes { get; set; } = null;
        public DbSet<ticket.Train> Trains { get; set; } = null;
        public DbSet<ticket.Order> Orders { get; set; } = null;
        public DbSet<ticket.RouteTrain> RouteTrains { get; set; } = null;
        public DbSet<ticket.User> Users { get; set; } = null;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var cascadeFKs = builder.Model.GetEntityTypes()
       .SelectMany(t => t.GetForeignKeys())
       .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.ClientNoAction;

            base.OnModelCreating(builder);
        }
    }


}
