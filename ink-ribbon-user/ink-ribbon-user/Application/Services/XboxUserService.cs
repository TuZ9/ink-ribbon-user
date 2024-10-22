using ink_ribbon_user.Domain.Dto.Xbox;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Xbox;
using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Application.Services
{
    public class XboxUserService : IXboxUserService
    {
        private readonly ILogger<XboxUserService> _logger;
        private readonly IXboxUserApiClient _xboxUserClient;
        public XboxUserService(ILogger<XboxUserService> logger, IXboxUserApiClient xboxUserClient)
        {
            _logger = logger;
            _xboxUserClient = xboxUserClient;
        }
        public Task<XboxUserDto> GetUserByGameTag(string gameTag)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
