using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Interfaces.ApiClientService;
using ink_ribbon_user.Infra.HttpClientBase;

namespace ink_ribbon_user.Infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var steamLogger = serviceProvider.GetService(typeof(ILogger<SteamUserApiClient>)) as ILogger<SteamUserApiClient>;

            services.AddHttpClient("Steam",
               client => { client.BaseAddress = new Uri(RunTimeConfig.SteamEndpoint); });

            services.AddSingleton<ISteamUserApiClient, SteamUserApiClient>(x =>
                new SteamUserApiClient(x.GetService<IHttpClientFactory>()!, steamLogger, "Steam"));

            return services;
        }
    }
}