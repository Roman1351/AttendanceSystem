// IRepositoryWrapper
using DataAccess.Interfaces;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task SaveAsync();
    }
}