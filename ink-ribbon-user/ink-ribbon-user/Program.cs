using Hangfire;
using Hangfire.MemoryStorage;
using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Infra.Extensions;
using ink_ribbon_user.Infra.Ioc.Hangfire;
using ink_ribbon_user.Infra.Ioc.Swagger;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
SwaggerConfiguration.AddSwagger(builder.Services);
RunTimeConfig.SetConfigs(builder.Configuration);
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
            //Environment = env.EnvironmentName,
            SystemEnvironment = Environment.GetEnvironmentVariable("dev"),
        });
        //context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});

app.UseRouting();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("All");
//app.MapHealthChecks();
app.MapControllers();
app.Run();
