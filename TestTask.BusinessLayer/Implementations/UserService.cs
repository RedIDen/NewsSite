using AutoMapper;
using TestTask.BusinessLayer.BusinessModels;
using TestTask.BusinessLayer.Interfaces;
using TestTask.DataAccess.DataModels;
using TestTask.DataAccess.Interfaces;

namespace TestTask.BusinessLayer.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<int> CreateUserAsync(RegisterModel user)
        {
            var userDataModel = this._mapper.Map<UserDataModel>(user);
            int result = await this._repository.CreateUserAsync(userDataModel);
            return result;
        }

        public async Task<UserModel?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            var result = this._mapper.Map<UserModel>(await this._repository.GetUserByLoginAndPasswordAsync(login, password));
            return result;
        }
    }
}
