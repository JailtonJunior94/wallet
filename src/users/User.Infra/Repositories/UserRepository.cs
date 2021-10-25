using System;
using System.Threading.Tasks;
using User.Domain.Interfaces;

namespace User.Infra.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository() : base("walletdb", "users") { }

        public async Task<Domain.Entities.User> CreateUserAsync(Domain.Entities.User user)
        {
            var response = await _container.CreateItemAsync(user);
            return response;
        }

        public Task<Domain.Entities.User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
