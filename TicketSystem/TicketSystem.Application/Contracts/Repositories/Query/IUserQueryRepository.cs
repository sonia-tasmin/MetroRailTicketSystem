using TicketSystem.Application.Contracts.Repositories.Query.Base;
using TicketSystem.Application.Queries.User;
using TicketSystem.Core.Entities;
using Shared.DTOs.Base;

namespace TicketSystem.Application.Contracts.Repositories.Query
{
    public interface IUserQueryRepository : IMultipleResultQueryRepository<User>
    {
        Task<IEnumerable<User>> GetAll(GetAllUserQuery getUserQuery);
        Task<User> GetById(Guid Id);
        Task<User> IsUserValid(string email, string password);
    }
}
