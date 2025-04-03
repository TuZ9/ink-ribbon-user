using ink_ribbon_user.Domain.Dto;

namespace ink_ribbon_user.Domain.Interfaces.Services
{
    public interface ISteamUserSevice
    {
        Task GetSteamId();
        Task<SteamUserDto> GetSteamUserById(string steamId);
        Task<SteamUserDto> GetSteamIdByName(string userName);
        Task<SteamUserDto> BuildSteamUser(string userName);
    }
}