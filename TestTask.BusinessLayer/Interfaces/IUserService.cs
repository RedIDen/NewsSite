using TestTask.BusinessLayer.BusinessModels;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> GetUserByLoginAndPasswordAsync(string login, string password);

        public Task<int> CreateUserAsync(RegisterModel user);
    }
}
