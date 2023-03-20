
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Contracts.Repositories.Cache;
using TicketSystem.Application.Contracts.Repositories.Security;
using TicketSystem.Application.Common.Models;

namespace TicketSystem.Application.Common.Security;

public class IdentityServerRepository : IIdentityServerRepository
{
    private readonly ICacheRepository _cacheRepository;
    private readonly IConfiguration _configuration;

    private string _endPoint;
    public IdentityServerRepository(ICacheRepository cacheRepository, IConfiguration configuration)
    {
        _cacheRepository = cacheRepository;
        _configuration = configuration;
        _endPoint = _configuration["Security:EndPoint"];
    }

    public async Task<IEnumerable<IdentityServerAccessConfiguration>> GetPermissions(string token, string clientId, string roleId)
    {
        if (bool.Parse(_configuration["CacheSettings:EnableSecurityCache"]))
        {
            var cachePermissions = await _cacheRepository.GetList<IdentityServerAccessConfiguration>($"{clientId}_{roleId}");
            if (cachePermissions != null && cachePermissions.Any())
                return cachePermissions;
        }

        using (HttpClient httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_endPoint}?RoleId={roleId}&ClientId={clientId}"),
                Method = HttpMethod.Get,
            };
            request.Headers.Add("Authorization", token);
            var response = await httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            var permissions = JsonConvert.DeserializeObject<IEnumerable<IdentityServerAccessConfiguration>>(result);
            if (permissions != null && permissions.Any())
                await _cacheRepository.InsertList<IdentityServerAccessConfiguration>($"{clientId}_{roleId}", permissions);
            return permissions;
        }
    }
}