using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.Seat;
using Shared.DTOs.Seat;

namespace TicketSystem.Application.Common.Mappings
{
    public class SeatMappingProfile : Profile
    {
        public SeatMappingProfile()
        {
            CreateMap<Seat, SeatGetResponseDTO>().ReverseMap();
            CreateMap<Seat, CreateSeatCommand>().ReverseMap();
            CreateMap<Seat, SeatPostResponseDTO>().ReverseMap();
            //CreateMap<Seat, DeleteSeatCommand>().ReverseMap();
            //CreateMap<Seat, UpdateSeatCommand>().ReverseMap();


        }
    }
}
