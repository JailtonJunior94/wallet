using System;
using User.Domain.Entities;
using System.Threading.Tasks;
using User.Domain.Interfaces;

namespace User.Infra.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository() : base("walletdb", "users") { }

        public async Task<Users> CreateUserAsync(Users user)
        {
            var response = await _container.CreateItemAsync(user);
            return response;
        }

        public Task<Users> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
