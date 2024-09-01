﻿namespace ink_ribbon_user.Domain.Interfaces.ApiClientService
{
    public interface IServiceClientBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(string url);
        Task<IEnumerable<TEntity?>> GetListAsync(string url);
        Task PostAsync(string url, TEntity obj);
        Task PutAsync(string url, TEntity obj);
        Task DeleteAsync(string url);
    }
}
