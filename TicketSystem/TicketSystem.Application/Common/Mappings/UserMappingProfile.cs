using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.User;
using Shared.DTOs.User;

namespace TicketSystem.Application.Common.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserGetResponseDTO>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UserPostResponseDTO>().ReverseMap();
            //CreateMap<Seat, DeleteSeatCommand>().ReverseMap();
            //CreateMap<Seat, UpdateSeatCommand>().ReverseMap();


        }
    }
}
