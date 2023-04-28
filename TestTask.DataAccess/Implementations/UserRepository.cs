using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private NewsSiteDbContext _context;

        public UserRepository(NewsSiteDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CreateUserAsync(UserDataModel user)
        {
            user.IsActivated = true;

            var savedUser = await this._context.Users.AddAsync(user);
            await this._context.SaveChangesAsync();

            return savedUser.Entity.Id;
        }

        public async Task<UserDataModel?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

            if (user == null)
            {
                return null;
            }

            return user.IsActivated ? user : null;
        }

        public async Task<bool> IsUserExist(string login)
        {
            return await this._context.Users.AnyAsync(x => x.Login == login);
        }
    }
}
