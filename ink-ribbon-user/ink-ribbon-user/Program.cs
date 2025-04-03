using Hangfire;
using Hangfire.MemoryStorage;
using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Infra.Extensions;
using ink_ribbon_user.Infra.Ioc.Hangfire;
using ink_ribbon_user.Infra.Ioc.Swagger;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Runtime;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
SwaggerConfiguration.AddSwagger(builder.Services);
RunTimeConfig.SetConfigs(builder.Configuration);
GCSettings.LatencyMode = GCLatencyMode.Batch;
builder.Services.AddHttpClients();
builder.Services.AddServices();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddCors(options => options.AddPolicy("All", opt => opt
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostname => true)));

builder.WebHost.UseKestrel(so =>
{
    so.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(10000);
    so.Limits.MaxRequestBodySize = 52428800;
    so.Limits.MaxConcurrentConnections = 100;
    so.Limits.MaxConcurrentConnections = 100;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHangfire(x =>
{
    x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
    x.UseSimpleAssemblyNameTypeSerializer();
    x.UseRecommendedSerializerSettings();
    x.UseMemoryStorage();
});

var app = builder.Build();

if (Debugger.IsAttached)
{
    app.UseHangfireDashboard("/hangfire");
}
else
{
    app.UseHangfireDashboard("/hangfire", new DashboardOptions()
    {
        Authorization = new[] { new HangfireAuthorizationFilter() },
        IgnoreAntiforgeryToken = true
    });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});

app.UseHealthChecks("/env", new HealthCheckOptions
{
    ResultStatusCodes =
                {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                },
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(new
        {
            SystemEnvironment = Environment.GetEnvironmentVariable("dev"),
        });
        await context.Response.WriteAsync(result);
    }
});
var serviceProvider = builder.Services.BuildServiceProvider();
HangireJobs.RunHangFireJob(serviceProvider);

app.UseRouting();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("All");
app.MapControllers();
app.Run();