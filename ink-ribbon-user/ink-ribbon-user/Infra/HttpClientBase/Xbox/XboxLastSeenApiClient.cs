using ink_ribbon_user.Application.Services;
using ink_ribbon_user.Domain.Dto.Xbox;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Xbox;

namespace ink_ribbon_user.Infra.HttpClientBase.Xbox
{
    public class XboxLastSeenApiClient : ServiceClientBase<XboxLastSeenDto, XboxLastSeenApiClient>, IXboxLastSeenApiClient
    {
        public XboxLastSeenApiClient(HttpClient clientFactory, ILogger<XboxLastSeenApiClient> logger) : base(clientFactory, logger)
        {
        }
    }
}