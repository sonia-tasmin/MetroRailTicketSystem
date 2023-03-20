using AutoMapper;
using TicketSystem.Core.Entities;
using Shared.Commands.Train;
using Shared.DTOs.Train;
using System.Diagnostics;

namespace TicketSystem.Application.Common.Mappings
{
    public class TrainMappingProfile : Profile
    {
        public TrainMappingProfile()
        {
            CreateMap<Train, TrainGetResponseDTO>().ReverseMap();
            CreateMap<Train, CreateTrainCommand>().ReverseMap();
            CreateMap<Train, TrainPostResponseDTO>().ReverseMap();


        }
    }
}
