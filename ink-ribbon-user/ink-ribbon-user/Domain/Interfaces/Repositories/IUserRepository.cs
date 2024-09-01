using ink_ribbon_user.Domain.Entities;

namespace ink_ribbon_user.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task Insert(IEnumerable<User> flower);
        Task Update(IEnumerable<User> flower);
        Task Delete(User flower);
    }
}
