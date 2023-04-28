using TestTask.BusinessLayer.BusinessModels;

namespace TestTask.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel?> GetUserByLoginAndPasswordAsync(string login, string password);

        public Task<bool> IsUserExist(string login);

        public Task<int> CreateUserAsync(RegisterModel user);
    }
}
