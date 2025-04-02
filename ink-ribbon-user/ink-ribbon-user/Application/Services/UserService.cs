using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Repositories;
using ink_ribbon_user.Domain.Interfaces.Services;

namespace ink_ribbon_user.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task Delete(string idUser)
        {
            try
            {
                await _userRepository.Delete(idUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> Get(string idUser)
        {
            try
            {
                var result = await _userRepository.Get(idUser);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Insert(User user)
        {
            try
            {
                await _userRepository.Insert(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
