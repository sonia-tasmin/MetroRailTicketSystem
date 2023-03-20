
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using TicketSystem.Application.Contracts.Repositories.Cache;
using TicketSystem.Application.Contracts.Repositories.Cache;

namespace TicketSystem.Infrastructure.Cache.Repositories;

public class CacheRepository : ICacheRepository
{
    private readonly IDistributedCache _redisCache;

    public CacheRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache;
    }

    public async Task<T> Get<T>(string key) where T : class
    {
        var obj = await _redisCache.GetStringAsync(key);
        if (obj == null)
            return default(T);
        return JsonConvert.DeserializeObject<T>(obj);
    }

    public async Task<IEnumerable<T>> GetList<T>(string key) where T : class
    {
        var listObj = await _redisCache.GetStringAsync(key);
        if (listObj == null)
            return null;
        return JsonConvert.DeserializeObject<IEnumerable<T>>(listObj);
    }

    public async Task Insert<T>(string key, T obj) where T : class
    {
        await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(obj));
    }

    public async Task InsertList<T>(string key, IEnumerable<T> listObj) where T : class
    {
        await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(listObj));
    }

    public async Task Remove(string key)
    {
        await _redisCache.RemoveAsync(key);
    }
}
