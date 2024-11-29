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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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
            return Ok(new { Message = "user created successfuly" });
        }

        [HttpPost("auth")]
        public async Task<ActionResult<AuthTokenResponse>> SingnInAsync([FromBody] AuthUser user)
        {
            return await _userService.SingnInAsync(user);
        }

    }

} 