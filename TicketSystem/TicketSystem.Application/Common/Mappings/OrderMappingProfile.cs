using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.Order;
using Shared.DTOs.Order;
using MassTransit.Transports;

namespace TicketSystem.Application.Common.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderGetResponseDTO>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, OrderPostResponseDTO>().ReverseMap();


        }
    }
}
