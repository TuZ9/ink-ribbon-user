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

            var steamLogger = serviceProvider.GetService(typeof(ILogger<SteamUserApiClient>)) as ILogger<SteamUserApiClient>;
            var xboxLogger = serviceProvider.GetService(typeof(ILogger<XboxUserApiClient>)) as ILogger<XboxUserApiClient>;

            services.AddHttpClient("Steam",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint); });

            services.AddHttpClient("Xbox",
               client => { client.BaseAddress = new Uri(RunTimeConfig.XboxEndpoint); });

            services.AddSingleton<IXboxUserApiClient, XboxUserApiClient>(x =>
                new XboxUserApiClient(x.GetService<IHttpClientFactory>()!, xboxLogger, "Steam"));

            services.AddSingleton<ISteamUserApiClient, SteamUserApiClient>(x =>
                new SteamUserApiClient(x.GetService<IHttpClientFactory>()!, steamLogger, "Steam"));

            return services;
        }
    }
}