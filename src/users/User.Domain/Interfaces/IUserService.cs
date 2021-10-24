using System;
using User.Domain.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace User.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ObjectResult> GetUserByIdAsync(Guid id);
        Task<ObjectResult> CreateUserAsync(CreateUserDto request);
    }
}
