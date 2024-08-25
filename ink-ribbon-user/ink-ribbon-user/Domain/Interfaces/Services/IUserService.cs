namespace ink_ribbon_user.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task Insert();
        Task Delete();
        Task Update();
        Task Get();
    }
}
