
namespace TicketSystem.Application.Contracts.Repositories.Cache;

public interface ICacheRepository
{
    Task<T> Get<T>(string key) where T : class;
    Task<IEnumerable<T>> GetList<T>(string key) where T : class;
    Task Insert<T>(string key, T obj) where T : class;
    Task InsertList<T>(string key, IEnumerable<T> listObj) where T : class;
    Task Remove(string key);
}
