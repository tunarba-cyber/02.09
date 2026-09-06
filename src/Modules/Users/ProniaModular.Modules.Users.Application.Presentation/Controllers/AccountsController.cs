using Microsoft.AspNetCore.Mvc;
using ProniaModular.Modules.Users.Application.DTOs.AppUser;
using ProniaModular.Modules.Users.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Users.Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto request)
        {
            await _authenticationService.RegisterAsync(request);
            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto request)
        {
            string token = await _authenticationService.LoginAsync(request);
            return Ok(new { Token = token });
        }
    }
}
