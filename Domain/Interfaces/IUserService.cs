// IUserService
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task CreateAsync(User model);
        Task UpdateAsync(User model);
        Task DeleteAsync(int id);
        Task GetAll();
        Task Update(User user);
        Task Delete(int id);
        Task GetById(int id);
    }
}