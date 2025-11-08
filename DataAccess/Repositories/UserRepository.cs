using AttendanceSystem.Infrastructure.Repositories;
using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}