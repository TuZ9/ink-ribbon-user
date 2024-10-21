using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Dto.Steam;
using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Steam;
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

        public async Task<SteamUserDto> BuildSteamUser(string userName)
        {
            try
            {
                var steamId = await GetSteamIdByName(userName);
                var steamUser = await GetSteamUserById(steamId.response.steamid);
                return steamUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public Task<SteamUser> GetSteamId()
        {
            throw new NotImplementedException();
        }

        public async Task<SteamUserDto> GetSteamIdByName(string userName)
        {
            try
            {
                var user = await _steamClient.GetAsync($"/ISteamUser/ResolveVanityURL/v0001/?key={RunTimeConfig.SteamKey}&vanityurl={userName}");

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
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
