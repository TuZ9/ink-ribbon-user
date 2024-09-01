﻿using Dapper;
using ink_ribbon_user.Domain.Interfaces.Repositories;
using ink_ribbon_user.Infra.Context;

namespace ink_ribbon_user.Infra.Repositories.Postgres
{
    public class BaseAuroraRepository<TEntity> : IDisposable, IBaseAuroraRepository<TEntity> where TEntity : class
    {
        private readonly AuroraDbContext _context;

        public BaseAuroraRepository(AuroraDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public void Dispose()
        {
        }

        public async Task<TEntity> GetAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                return await con.QueryFirstAsync<TEntity>(query, param);
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<TEntity>(query, param);
            }
        }

        public async Task InsertAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public async Task UpdateAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }
    }
}