using AutoMapper;
using MediatR;
using TicketSystem.Application.Contracts.Repositories.Query;

using Shared.DTOs.User;

namespace TicketSystem.Application.Queries.User
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserGetResponseDTO>>
    {
        private readonly IUserQueryRepository _UserQueryRepository;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserQueryRepository userQueryRepository, IMapper mapper)
        {
            _UserQueryRepository = userQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserGetResponseDTO>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Core.Entities.User>, IEnumerable<UserGetResponseDTO>>(await _UserQueryRepository.GetAll(request));
        }
    }
}
