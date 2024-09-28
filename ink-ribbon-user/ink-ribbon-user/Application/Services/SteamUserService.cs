using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Dto;
using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.ApiClientService;
using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Application.Services
{
    public class SteamUserService : ISteamUserSevice
    {
        private readonly ILogger<SteamUserService> _logger;
        private readonly ISteamUserApiClient _steamClient;

        public SteamUserService(ILogger<SteamUserService> logger, ISteamUserApiClient steamClient)
        {
            _logger = logger;
            _steamClient = steamClient;
        }

        public Task<SteamUser> GetSteamId()
        {
            throw new NotImplementedException();
        }

        public async Task<SteamUserDto> GetSteamUserById(string steamId)
        {
            try
            {
                var user = await _steamClient.GetAsync($"/ISteamUser/GetPlayerSummaries/v0002/?key={RunTimeConfig.SteamKey}&steamids={steamId}");

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
