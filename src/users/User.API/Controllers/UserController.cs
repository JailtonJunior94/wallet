using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using User.Domain.Dtos;
using User.Domain.Interfaces;
using System;
using User.Domain.Entities;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto request)
        {
            Account account = new(150);
            Domain.Entities.User user = new("Jailton", new DateTime(1994, 01, 06), account);
            var response = await _repository.CreateUserAsync(user);

            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
