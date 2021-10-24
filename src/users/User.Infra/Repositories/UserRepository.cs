using System;
using System.Threading.Tasks;
using User.Domain.Interfaces;

namespace User.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        public Task<Domain.Entities.User> CreateUserAsync(Domain.Entities.User user)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
