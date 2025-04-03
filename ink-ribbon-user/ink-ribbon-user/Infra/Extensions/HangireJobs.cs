using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Infra.Extensions
{
    public static class HangireJobs
    {
        public static async void RunHangFireJob(ServiceProvider services)
        {
            await RunJobs(services);
        }
        public static async Task RunJobs(ServiceProvider services)
        {
            using var scope = services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISteamUserSevice>();
            await service.GetSteamId();
            //BackgroundJob.Enqueue(() => service.BuildBase());
        }
    }
}
