// IUserRepository
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}