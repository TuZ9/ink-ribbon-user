using ink_ribbon_user.Domain.Entities;
using ink_ribbon_user.Domain.Interfaces.Repositories;
using ink_ribbon_user.Infra.Context;

namespace ink_ribbon_user.Infra.Repositories.Postgres
{
    public class UserRepository : BaseAuroraRepository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(AuroraDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task Delete(User flower)
        {
            try
            {
                var query = @"DELETE FROM users WHERE IdUser = 'your-iduser-uuid';";
                await DeleteAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                return await GetListAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(IEnumerable<User> flower)
        {
            try
            {
                var query = @"INSERT INTO users (IdUser, IdUserSteam, RealName, GamerTag, Avatar, Avatarmedium, Avatarfull, Email) VALUES 
                            ('your-iduser-uuid', 'your-idusersteam-uuid', 'Real Name', 'GamerTag', 'AvatarURL', 'AvatarMediumURL', 'AvatarFullURL', 'email@example.com');";

                await InsertAsync(query, flower);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Inserir Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(IEnumerable<User> flower)
        {
            try
            {
                var query = @"UPDATE users
                              SET 
                                  IdUserSteam = 'new-idusersteam-uuid',
                                  RealName = 'New Real Name',
                                  GamerTag = 'New GamerTag',
                                  Avatar = 'NewAvatarURL',
                                  Avatarmedium = 'NewAvatarMediumURL',
                                  Avatarfull = 'NewAvatarFullURL',
                                  Email = 'newemail@example.com'
                              WHERE 
                                  IdUser = 'your-iduser-uuid';";

                await UpdateAsync(query, flower);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
