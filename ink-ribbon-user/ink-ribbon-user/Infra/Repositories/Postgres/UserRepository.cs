using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Repositories;
using ink_ribbon_user.Infra.Context;

namespace ink_ribbon_user.Infra.Repositories.Postgres
{
    public class UserRepository : BaseAuroraRepository<User>, IUserRepository
    {
        public UserRepository(AuroraDbContext context) : base(context)
        {
        }

        public Task Delete(User flower)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Insert(IEnumerable<User> flower)
        {
            throw new NotImplementedException();
        }

        public Task Update(IEnumerable<User> flower)
        {
            throw new NotImplementedException();
        }
    }
}
