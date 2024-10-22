using ink_ribbon_user.Application.Services;
using ink_ribbon_user.Domain.Dto.Xbox;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Xbox;

namespace ink_ribbon_user.Infra.HttpClientBase.Xbox
{
    public class XboxUserApiClient : ServiceClientBase<XboxUserDto, XboxUserApiClient>, IXboxUserApiClient
    {
        public XboxUserApiClient(IHttpClientFactory clientFactory, ILogger<XboxUserApiClient> logger, string clientName) : base(clientFactory, logger, clientName)
        {
        }
    }
}