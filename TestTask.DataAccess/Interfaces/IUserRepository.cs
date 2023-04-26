using TestTask.DataAccess.DataModels;

namespace TestTask.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDataModel?> GetUserByLoginAndPasswordAsync(string login, string password);

        public Task<int> CreateUserAsync(UserDataModel user);
    }
}
