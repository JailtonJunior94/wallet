using System;
using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Entities.User> CreateUserAsync(Entities.User user);
        Task<Entities.User> GetUserById(Guid id);
    }
}
