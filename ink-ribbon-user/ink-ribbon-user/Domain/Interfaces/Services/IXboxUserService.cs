using ink_ribbon_user.Domain.Dto.Xbox;

namespace ink_ribbon_user.Domain.Interfaces.Services
{
    public interface IXboxUserService
    {
        Task<XboxLastSeenDto> GetLastSeenStatus(string xuid);
        Task<XboxUserDto> GetUserByGameTag(string gamerTag);
    }
}
