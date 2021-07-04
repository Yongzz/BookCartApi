
using BookCartApi.Models;
using BookCartApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User model)
        {
            model.EmailConfirmed = true;
            model.PasswordHash = model.PasswordHash;
            var result = await _userService.CreateUser(model);
            return Ok(result);
        }
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }
        [HttpPost("logout")]
        public async Task SignOutAsync()
        {
            await _userService.SignOutAsync();
        }

    }
}
