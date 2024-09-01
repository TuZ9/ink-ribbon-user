using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Application.Services
{
    public class SteamUserService : ISteamUserSevice
    {
        private readonly ILogger<SteamUserService> _logger;
        public SteamUserService(ILogger<SteamUserService> logger) { _logger = logger; }
        public Task<SteamUser> GetSteamId()
        {
            throw new NotImplementedException();
        }

        public Task<SteamUser> GetSteamUser()
        {
            throw new NotImplementedException();
        }
    }
}
