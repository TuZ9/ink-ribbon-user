using ink_ribbon_user.Domain.Dto;
using ink_ribbon_user.Domain.Entities;

namespace ink_ribbon_user.Domain.Interfaces.Services
{
    public interface ISteamUserSevice
    {
        Task<SteamUser> GetSteamId();
        Task<SteamUserDto> GetSteamUserById(string steamId);
        Task<SteamUserDto> GetSteamIdByName(string userName);
    }
}