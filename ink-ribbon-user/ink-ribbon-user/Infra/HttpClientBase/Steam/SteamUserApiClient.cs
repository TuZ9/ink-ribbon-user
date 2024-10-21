using ink_ribbon_user.Application.Services;
using ink_ribbon_user.Domain.Dto.Steam;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Steam;

namespace ink_ribbon_user.Infra.HttpClientBase.Steam
{
    public class SteamUserApiClient : ServiceClientBase<SteamUserDto, SteamUserApiClient>, ISteamUserApiClient
    {
        public SteamUserApiClient(IHttpClientFactory clientFactory, ILogger<SteamUserApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}
