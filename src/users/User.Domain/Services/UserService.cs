using System;
using User.Domain.Dtos;
using System.Threading.Tasks;
using User.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace User.Domain.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public Task<ObjectResult> CreateUserAsync(CreateUserDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
