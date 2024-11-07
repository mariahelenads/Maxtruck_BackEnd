using Maxtruck.Api.Configurations;
using Maxtruck.Application.Dtos;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxtruck.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsersAsync()
        {
            return await _userService.ListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] UserDto user)
        {
            await _userService.CreateUserAsync(user);
            return Ok("user created successfuly");
        }

        [HttpPost("auth")]
        public async Task<ActionResult> SingnInAsync([FromBody] AuthUser user)
        {
            Console.WriteLine($"Email {user.Email} passworkd {user.Password}");
            var token = await _userService.SingnInAsync(user);

            return Ok(new { Token = token });
        }

    }

} 