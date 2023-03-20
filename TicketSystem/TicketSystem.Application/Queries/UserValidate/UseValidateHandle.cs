using TicketSystem.Application.Contracts.Repositories.Query;

namespace TicketSystem.Application.Queries.UserValidate;

public class UseValidateHandle : IRequestHandler<GetuserValidateQuery, object>
{
    private readonly IUserQueryRepository _UserQueryRepository;
    private readonly IMapper _mapper;
    public UseValidateHandle(IUserQueryRepository userQueryRepository, IMapper mapper)
    {
        _UserQueryRepository = userQueryRepository;
        _mapper = mapper;
    }
    public async Task<object> Handle(GetuserValidateQuery request, CancellationToken cancellationToken)
    {
        var result =await _UserQueryRepository.IsUserValid(request.email, request.password);
        return result;
    }
}
