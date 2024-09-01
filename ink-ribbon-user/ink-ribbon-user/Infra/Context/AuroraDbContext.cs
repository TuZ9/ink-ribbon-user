using ink_ribbon_user.Application.Static;
using Npgsql;
using System.Data;

namespace ink_ribbon_user.Infra.Context
{
    public class AuroraDbContext : IDisposable
    {

        public AuroraDbContext()
        {
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(RunTimeConfig.Auroraconnection);

        public void Dispose()
        {
        }
    }
}