using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using User.Domain.Dtos;
using User.Domain.Interfaces;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            var response = await _userService.CreateUserAsync(command);
            return response;
        }
    }
}
