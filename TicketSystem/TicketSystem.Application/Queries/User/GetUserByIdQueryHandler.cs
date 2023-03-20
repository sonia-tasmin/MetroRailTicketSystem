using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;
using Shared.DTOs.User;

namespace TicketSystem.Application.Queries.User
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserGetResponseDTO>
    {
        private readonly IUserQueryRepository _UserQueryRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserQueryRepository UserQueryRepository, IMapper mapper)
        {
            _UserQueryRepository = UserQueryRepository;
            _mapper = mapper;
        }

        public async Task<UserGetResponseDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Core.Entities.User, UserGetResponseDTO>(await _UserQueryRepository.GetById(request.UserId));
        }
    }
}
