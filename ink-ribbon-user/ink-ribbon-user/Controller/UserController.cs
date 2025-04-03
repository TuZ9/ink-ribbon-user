using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ink_ribbon_user.Domain.Dto;
using RabbitMQ.Client;
using System.Text;

namespace ink_ribbon_user.Controller
{
    [ApiController]
    [EnableCors("All")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("User/InsertUser")]
        public async Task<IActionResult> InsertUser(User user)
        {
            await _userService.Insert(user);

            return Ok(user);
        }

        [HttpGet("User/getgame")]
        public async Task<IActionResult> getgame()
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
                            var body = Encoding.UTF8.GetBytes(g.ToString());

                            await channel.BasicPublishAsync(exchange: "",
                                                        routingKey: "fila.teste",
                                                        body: body);
                        }                        
                    }

                }

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
