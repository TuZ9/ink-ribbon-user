using ink_ribbon_user.Application.Services;
using ink_ribbon_user.Domain.Dto;
using ink_ribbon_user.Domain.Interfaces.ApiClientService;

namespace ink_ribbon_user.Infra.HttpClientBase
{
    public class SteamUserApiClient : ServiceClientBase<SteamUserDto, SteamUserApiClient>, ISteamUserApiClient
    {
        public SteamUserApiClient(IHttpClientFactory clientFactory, ILogger<SteamUserApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}
