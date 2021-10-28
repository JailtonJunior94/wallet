using System;
using User.Domain.Dtos;
using User.Domain.Entities;
using System.Threading.Tasks;
using User.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace User.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ObjectResult> CreateUserAsync(CreateUserCommand command)
        {
            var user = await _userRepository.CreateUserAsync(new Users(command.Name, command.Birthday));
            return new ObjectResult(user) { StatusCode = StatusCodes.Status201Created };
        }

        public Task<ObjectResult> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
