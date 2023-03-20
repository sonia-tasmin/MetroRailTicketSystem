using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.RouteTrain;
using Shared.DTOs.RouteTrain;

namespace TicketSystem.Application.Common.Mappings
{
    public class RouteTrainMappingProfile : Profile
    {
        public RouteTrainMappingProfile()
        {
            CreateMap<RouteTrain, RouteTrainGetResponseDTO>().ReverseMap();
            CreateMap<RouteTrain, CreateRouteTrainCommand>().ReverseMap();
            CreateMap<RouteTrain, RouteTrainPostResponseDTO>().ReverseMap();
            //CreateMap<RouteTrain, DeleteRouteTrainCommand>().ReverseMap();
            //CreateMap<RouteTrain, UpdateRouteTrainCommand>().ReverseMap();


        }
    }
}
