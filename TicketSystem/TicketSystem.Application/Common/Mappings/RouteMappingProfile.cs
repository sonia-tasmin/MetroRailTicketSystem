using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.Route;
using Shared.DTOs.Route;

namespace TicketSystem.Application.Common.Mappings
{
    public class RouteMappingProfile : Profile
    {
        public RouteMappingProfile()
        {
            CreateMap<Route, RouteGetResponseDTO>().ReverseMap();
            CreateMap<Route, CreateRouteCommand>().ReverseMap();
            CreateMap<Route, RoutePostResponseDTO>().ReverseMap();


        }
    }
}
