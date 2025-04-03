using ink_ribbon_user.Application.Static;
using ink_ribbon_user.Domain.Dto;
using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.ApiClientService;
using ink_ribbon_user.Domain.Interfaces.Services;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ink_ribbon_user.Application.Services
{
    public class SteamUserService : ISteamUserSevice
    {
        private readonly ILogger<SteamUserService> _logger;
        private readonly ISteamUserApiClient _steamClient;

        public SteamUserService(ILogger<SteamUserService> logger, ISteamUserApiClient steamClient)
        {
            _logger = logger;
            _steamClient = steamClient;
        }

        public async Task<SteamUserDto> BuildSteamUser(string userName)
        {
            try
            {
                var steamId = await GetSteamIdByName(userName);
                var steamUser = await GetSteamUserById(steamId.response.steamid);
                return steamUser;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task GetSteamId()
        {
            try
            {
                var _httpClient = new HttpClient();

                using var httpResponseMessage = await _httpClient.GetAsync("https://api.steampowered.com/ISteamApps/GetAppList/v2/");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<GamesDto>(contentStream);
                    var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", Port = 5672 };
                    using (var connection = await factory.CreateConnectionAsync())


                    using (var channel = await connection.CreateChannelAsync())
                    {
                        await channel.QueueDeclareAsync(queue: "fila.teste",
                                                    durable: true,
                                                    exclusive: false,
                                                    autoDelete: false,
                                                    arguments: null);
                        foreach (var g in result.applist.apps)
                        {
                            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(g));
                            
                            await channel.BasicPublishAsync(exchange: "",
                                                        routingKey: "fila.teste",
                                                        body: body);
                            _logger.LogInformation($"Messagem publicada Serilog {JsonSerializer.Serialize(g)}");
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SteamUserDto> GetSteamIdByName(string userName)
        {
            try
            {
                var user = await _steamClient.GetAsync($"/ISteamUser/ResolveVanityURL/v0001/?key={RunTimeConfig.SteamKey}&vanityurl={userName}");

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<SteamUserDto> GetSteamUserById(string steamId)
        {
            try
            {
                var user = await _steamClient.GetAsync($"/ISteamUser/GetPlayerSummaries/v0002/?key={RunTimeConfig.SteamKey}&steamids={steamId}");

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
