using System;
using User.Domain.Entities;
using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> CreateUserAsync(Users user);
        Task<Users> GetUserById(Guid id);
    }
}
