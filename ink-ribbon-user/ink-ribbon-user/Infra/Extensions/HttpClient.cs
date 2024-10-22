using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Steam;
using ink_ribbon_user.Domain.Interfaces.ApiClientService.Xbox;
using ink_ribbon_user.Infra.HttpClientBase.Steam;
using ink_ribbon_user.Infra.HttpClientBase.Xbox;

namespace ink_ribbon_user.Infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            services.AddHttpClient<ISteamUserApiClient, SteamUserApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint));
            services.AddHttpClient<IXboxUserApiClient, XboxUserApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.XboxEndpoint));

            return services;
        }
    }
}