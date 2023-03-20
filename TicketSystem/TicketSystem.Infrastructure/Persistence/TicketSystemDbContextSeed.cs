using MassTransit;
using TicketSystem.Core.Entities;
using System.Linq;

namespace TicketSystem.Infrastructure.Persistence;
public class TicketSystemDbContextSeed
{
    private static readonly Guid USER_ID = Guid.Parse("81330491-85f3-4bb9-b372-ed5851b2d470");
    /*    public static async Task SeedAsync(TicketSystemDbContext context, IServiceProvider services)
        {
            if (!context.TicketSystemTypes.Any())
            {
                context.TicketSystemTypes.AddRange(GetSeedTicketSystemTypes());
                await context.SaveChangesAsync();
            }
            if (!context.Seats.Any())
            {
                context.Seats.AddRange(GetSeedSeats());
                await context.SaveChangesAsync();
            }
        }
        private static IEnumerable<TicketSystemType> GetSeedTicketSystemTypes()
        {
            return new List<TicketSystemType>
            {
                new TicketSystemType{Id=Guid.Parse("2ec9e50d-cda9-4d08-a3a1-c7a7e503decb"),Name="A",DisplayName="A",Status=true,CreatedBy=USER_ID,CreatedDate=DateTime.UtcNow,AuthorizeStatus="A",IsDeleted=false},
                new TicketSystemType{Id=Guid.Parse("efa9cbc5-4bc9-44f1-894f-6989c59735f4"),Name="B",DisplayName="B",Status=true,CreatedBy=USER_ID,CreatedDate=DateTime.UtcNow,AuthorizeStatus="A",IsDeleted=false}
            };
        }*/

    /*    private static IEnumerable<Seat> GetSeedSeats()
        {
            return new List<Seat>
            {
                new Seat{Id=Guid.NewGuid(),SeatName="s1", Price=60,Ordered=false,TrainId},
                new Seat{Id=Guid.NewGuid(),SeatName="s2", Price=60,Ordered=false},

            };
        }*/
    private static IEnumerable<Route> GetSeedRoutes()
    {
        return new List<Route>
        {
            new Route{Id=Guid.NewGuid(),RouteName="uttara-agargaon"},
            new Route{Id=Guid.NewGuid(),RouteName="uttara-agargaon"},

        };
    }
    private static IEnumerable<Train> GetSeedTrains()
    {
        return new List<Train>
        {
            new Train{Id=Guid.NewGuid(),TrainName="Train1"},
            new Train{Id=Guid.NewGuid(),TrainName="Train2"},

        };
    }
    /*private static IEnumerable<RouteTrain> GetSeedRouteTrains()
    {
        return new List<RouteTrain>
        {
            new RouteTrain{Id=Guid.NewGuid(),TrainId="Train1", Route="uttara-agargaon",Active=false},
            new RouteTrain{Id=Guid.NewGuid(),Train="Train2", Route="uttara-agargaon",Active=false},

        };
    }*/
    private static IEnumerable<User> GetSeedUsers()
    {
        return new List<User>
        {
            new User{Id=Guid.NewGuid(),Name="admin", Email="a@gmail.com",Password="admin1999", UserType="ADMIN",UserTypeStatus=true},
            new User{Id=Guid.NewGuid(),Name="mango", Email="m@gmail.com",Password="12345678", UserType="USER",UserTypeStatus=false},

        };
    }
}
