using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Wrapper;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return _repositoryWrapper.User.FindAll().ToList();
        }

        public async Task<User> GetById(int id)
        {
            return _repositoryWrapper.User.FindByCondition(u => u.Id == id).FirstOrDefault();
        }

        public async Task Create(User model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _repositoryWrapper.User.Delete(user);
                _repositoryWrapper.Save();
            }
        }
    }
}