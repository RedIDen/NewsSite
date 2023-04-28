using TestTask.DataAccess.DataModels;

namespace TestTask.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDataModel?> GetUserByLoginAndPasswordAsync(string login, string password);

        public Task<bool> IsUserExist(string login);

        public Task<int> CreateUserAsync(UserDataModel user);
    }
}
