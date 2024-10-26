using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Dto.Xbox;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Xbox;
using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Application.Services
{
    public class XboxUserService : IXboxUserService
    {
        private readonly ILogger<XboxUserService> _logger;
        private readonly IXboxUserApiClient _xboxUserClient;
        private readonly IXboxAchievementApiClient _xboxLastSeenApiClient;
        public XboxUserService(ILogger<XboxUserService> logger, IXboxUserApiClient xboxUserClient, IXboxAchievementApiClient xboxLastSeenApiClient)
        {
            _logger = logger;
            _xboxUserClient = xboxUserClient;
            _xboxLastSeenApiClient = xboxLastSeenApiClient;
        }
        public async Task<XboxUserDto> GetUserByGameTag(string gamerTag)
        {
            try
            {
                var user = await _xboxUserClient.SendAsync($"api/v2/search/{gamerTag}", RunTimeConfig.XboxKey);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<XboxLastSeenDto> GetLastSeenStatus(string xuid)
        {
            try
            {
                var lastSeen = await _xboxLastSeenApiClient.SendListAsync($"/api/v2/{xuid}/presence", RunTimeConfig.XboxKey);

                return lastSeen.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
