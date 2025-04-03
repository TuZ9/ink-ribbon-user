using ink_ribbon_user.Application.Services;
using ink_ribbon_user.Domain.Interfaces.Repositories;
using ink_ribbon_user.Domain.Interfaces.Services;
using ink_ribbon_user.Infra.Context;
using ink_ribbon_user.Infra.Repositories.Postgres;

namespace ink_ribbon_user.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .RegisterServices();
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped(_ => new AuroraDbContext())
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ISteamUserSevice, SteamUserService>();
        }
    }
}
