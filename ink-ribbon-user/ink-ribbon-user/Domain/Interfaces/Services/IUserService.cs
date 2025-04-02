using ink_ribbon_user.Domain.Entities;

namespace ink_ribbon_user.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task Insert(User user);
        Task Delete(string idUser);
        Task Update(User user);
        Task<User> Get(string idUser);
    }
}
